
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace ET
{
public partial struct vec3
{
    public float X;
    public float Y;
    public float Z;

    public void Init(Tables tables)
    {
        PostInit();
        ResolveRef(tables);
    }

    public  void ResolveRef(Tables tables)
    {
        
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "x:" + X + ","
        + "y:" + Y + ","
        + "z:" + Z + ","
        + "}";
    }

    partial void PostInit();
}
}
