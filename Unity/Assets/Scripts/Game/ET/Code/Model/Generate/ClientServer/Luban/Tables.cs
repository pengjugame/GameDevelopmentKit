
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
public partial class Tables
{
    public DTStartMachineConfig DTStartMachineConfig { private set; get; }
    public DTStartProcessConfig DTStartProcessConfig { private set; get; }
    public DTStartSceneConfig DTStartSceneConfig { private set; get; }
    public DTStartZoneConfig DTStartZoneConfig { private set; get; }
    public DTOneConfig DTOneConfig { private set; get; }
    public DTAIConfig DTAIConfig { private set; get; }
    public DTUnitConfig DTUnitConfig { private set; get; }
    public DTDemo DTDemo { private set; get; }

    public Tables()
    {
        DTStartMachineConfig = new DTStartMachineConfig(this);
        DTStartProcessConfig = new DTStartProcessConfig(this);
        DTStartSceneConfig = new DTStartSceneConfig(this);
        DTStartZoneConfig = new DTStartZoneConfig(this);
        DTOneConfig = new DTOneConfig(this);
        DTAIConfig = new DTAIConfig(this);
        DTUnitConfig = new DTUnitConfig(this);
        DTDemo = new DTDemo(this);

        PostInit();
    }

    partial void PostInit();
}
}

