﻿using System;
using System.Collections.Generic;
using System.Text;
using Message;
using RedStone.Data;

namespace RedStone
{

    public class UserMessageHandle
    {
        public string sessionID { get; private set; }
        private Plugins.EventManager m_eventMgr = new Plugins.EventManager();

        public UserDaoProxy dao { get { return ProxyManager.instance.GetProxy<UserDaoProxy>(); } }
        public UserProxy userProxy { get { return ProxyManager.instance.GetProxy<UserProxy>(); } }
        public BattleServerProxy battleProxy { get { return ProxyManager.instance.GetProxy<BattleServerProxy>(); } }
        private UserData data { get { return userProxy.GetData(sessionID); } }


        public void Init(string sessionID)
        {
            this.sessionID = sessionID;
            RegisterMsg<CMLoginRequest>(OnLogin);
            RegisterMsg<CMMatchRequest>(OnBeginMatch);
        }

        public void Logout()
        {
            data.SetState(UserState.Offline);
            dao.Logout(data.uid);
            Debug.Log($"{data.uid} logout");
        }

        private void OnLogin(CMLoginRequest msg)
        {
            var db = dao.Login(msg.DeviceID);
            data.SetData(sessionID, db);

            Debug.Log($"{data.uid} login");

            CMLoginReply reply = new CMLoginReply();
            reply.PlayerInfo = new PlayerInfo();
            reply.PlayerInfo.Exp = data.exp;
            reply.PlayerInfo.Gold = data.gold;
            reply.PlayerInfo.Level = data.level;
            reply.PlayerInfo.Name = data.name;
            reply.PlayerInfo.Uid = data.uid;
            SendMessage(reply);

            data.SetState(UserState.Hall);
        }


        private void OnBeginMatch(CMMatchRequest req)
        {
            //TODO: Game Id Game Mode...

            CMMatchReply rep = new CMMatchReply();
            rep.WaitTime = 10;
            if (battleProxy.GetBestBattleServer() == null)
                rep.Status = 0;
            else
                rep.Status = 1;
            SendMessage(rep);

            data.SetState(UserState.Matching);
        }

        public void MactchSuccess(BattleServerData server, RoomData room)
        {
            CMMatchSuccess msg = new CMMatchSuccess();
            msg.BattleServerInfo = new BattleServerInfo();
            msg.BattleServerInfo.Address = server.address;
            msg.BattleServerInfo.Name = server.name;
            msg.BattleServerInfo.State = server.state.ToString();
            msg.BattleServerInfo.Token = room.token;
            SendMessage(msg);

            data.SetState(UserState.Game);
        }


        private void RegisterMsg<T>(Action<T> action)
        {
            m_eventMgr.Register(typeof(T).Name, action);
        }

        public void OnMessage(object message)
        {
            m_eventMgr.Send(message.GetType().Name, message);
        }

        public void SendMessage<T>(T msg)
        {
            userProxy.SendMessage(sessionID, msg);
        }
    }
}