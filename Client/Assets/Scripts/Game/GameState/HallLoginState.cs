using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedStone
{
    public class HallLoginState : AbstractState
    {
        public override void Enter(params object[] param)
        {
            Connect();
        }

        private void Connect()
        {
            GF.Send(EventDef.HallLoading, new LoadingStatus(LTKey.LOADING_WAIT_RESPONSE, 50));
            GF.GetProxy<HallProxy>().Connect();
        }

        public override void Leave()
        {
        }


        private bool m_lastConnected = false;
        private bool m_lastLogin = false;
        public override void Update()
        {
            if (!m_lastConnected && GF.GetProxy<HallProxy>().isConnected)
            {
                GF.Send(EventDef.HallLoading, new LoadingStatus(LTKey.LOADING_WAIT_LOGIN, 70));
            }

            m_lastConnected = GF.GetProxy<HallProxy>().isConnected;


            if (!m_lastLogin && GF.GetProxy<HallProxy>().isLogin)
            {
                GF.Send(EventDef.HallLoading, new LoadingStatus(LTKey.GENRAL_START, 98));
                Task.WaitFor(0.5f, () =>
                {
                    GF.ChangeState<HallState>();
                });
            }
            m_lastLogin = GF.GetProxy<HallProxy>().isLogin;
        }
    }
}
