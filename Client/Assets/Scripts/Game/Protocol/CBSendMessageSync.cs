// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: CBSendMessageSync.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Message {

  /// <summary>Holder for reflection information generated from CBSendMessageSync.proto</summary>
  public static partial class CBSendMessageSyncReflection {

    #region Descriptor
    /// <summary>File descriptor for CBSendMessageSync.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CBSendMessageSyncReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChdDQlNlbmRNZXNzYWdlU3luYy5wcm90bxIHbWVzc2FnZSI6ChFDQlNlbmRN",
            "ZXNzYWdlU3luYxIUCgxmcm9tUGxheWVySUQYASABKAUSDwoHY29udGVudBgC",
            "IAEoCWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Message.CBSendMessageSync), global::Message.CBSendMessageSync.Parser, new[]{ "FromPlayerID", "Content" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class CBSendMessageSync : pb::IMessage<CBSendMessageSync> {
    private static readonly pb::MessageParser<CBSendMessageSync> _parser = new pb::MessageParser<CBSendMessageSync>(() => new CBSendMessageSync());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CBSendMessageSync> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Message.CBSendMessageSyncReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CBSendMessageSync() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CBSendMessageSync(CBSendMessageSync other) : this() {
      fromPlayerID_ = other.fromPlayerID_;
      content_ = other.content_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CBSendMessageSync Clone() {
      return new CBSendMessageSync(this);
    }

    /// <summary>Field number for the "fromPlayerID" field.</summary>
    public const int FromPlayerIDFieldNumber = 1;
    private int fromPlayerID_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int FromPlayerID {
      get { return fromPlayerID_; }
      set {
        fromPlayerID_ = value;
      }
    }

    /// <summary>Field number for the "content" field.</summary>
    public const int ContentFieldNumber = 2;
    private string content_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Content {
      get { return content_; }
      set {
        content_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CBSendMessageSync);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CBSendMessageSync other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (FromPlayerID != other.FromPlayerID) return false;
      if (Content != other.Content) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (FromPlayerID != 0) hash ^= FromPlayerID.GetHashCode();
      if (Content.Length != 0) hash ^= Content.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (FromPlayerID != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(FromPlayerID);
      }
      if (Content.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Content);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (FromPlayerID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(FromPlayerID);
      }
      if (Content.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Content);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CBSendMessageSync other) {
      if (other == null) {
        return;
      }
      if (other.FromPlayerID != 0) {
        FromPlayerID = other.FromPlayerID;
      }
      if (other.Content.Length != 0) {
        Content = other.Content;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            FromPlayerID = input.ReadInt32();
            break;
          }
          case 18: {
            Content = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
