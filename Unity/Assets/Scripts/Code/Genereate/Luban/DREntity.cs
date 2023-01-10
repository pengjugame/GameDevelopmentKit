//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace Game
{
public sealed partial class DREntity :  Bright.Config.BeanBase 
{
    public DREntity(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        AssetName = _buf.ReadString();
        EntityGroupName = _buf.ReadString();
        Priority = _buf.ReadInt();
        PostInit();
    }

    public static DREntity DeserializeDREntity(ByteBuf _buf)
    {
        return new DREntity(_buf);
    }

    /// <summary>
    /// 实体编号
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 资源名称
    /// </summary>
    public string AssetName { get; private set; }
    /// <summary>
    /// 实体组名称
    /// </summary>
    public string EntityGroupName { get; private set; }
    /// <summary>
    /// 加载优先级
    /// </summary>
    public int Priority { get; private set; }

    public const int __ID__ = 93435409;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "AssetName:" + AssetName + ","
        + "EntityGroupName:" + EntityGroupName + ","
        + "Priority:" + Priority + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}