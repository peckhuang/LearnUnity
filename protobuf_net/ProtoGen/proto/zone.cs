//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: zone.proto
namespace com.tencent.ml.protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LoginReq")]
  public partial class LoginReq : global::ProtoBuf.IExtensible
  {
    public LoginReq() {}
    
    private int _uin;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"uin", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int uin
    {
      get { return _uin; }
      set { _uin = value; }
    }
    private int _login_type = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"login_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int login_type
    {
      get { return _login_type; }
      set { _login_type = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LoginRsp")]
  public partial class LoginRsp : global::ProtoBuf.IExtensible
  {
    public LoginRsp() {}
    
    private int _ret;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ret", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int ret
    {
      get { return _ret; }
      set { _ret = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}