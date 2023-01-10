//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Threading.Tasks;



namespace ET
{ 
public partial class Tables
{
    public DTOneConfig DTOneConfig {private set; get; }
    public DTAIConfig DTAIConfig {private set; get; }
    public DTUnitConfig DTUnitConfig {private set; get; }

    private System.Collections.Generic.Dictionary<string, object> _tables;

    public IDataTable GetDataTable(string tableName) => _tables.TryGetValue(tableName, out var v) ? v as IDataTable : null;

    public async Task LoadAsync(System.Func<string, Task<ByteBuf>> loader)
    {
        _tables = new System.Collections.Generic.Dictionary<string, object>();
        DTOneConfig = new DTOneConfig(loader("dtoneconfig")); 
        await DTOneConfig.LoadAsync();
        _tables.Add("DTOneConfig", DTOneConfig);
        DTAIConfig = new DTAIConfig(loader("dtaiconfig")); 
        await DTAIConfig.LoadAsync();
        _tables.Add("DTAIConfig", DTAIConfig);
        DTUnitConfig = new DTUnitConfig(loader("dtunitconfig")); 
        await DTUnitConfig.LoadAsync();
        _tables.Add("DTUnitConfig", DTUnitConfig);

        PostInit();
        DTOneConfig.Resolve(_tables); 
        DTAIConfig.Resolve(_tables); 
        DTUnitConfig.Resolve(_tables); 
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        DTOneConfig.TranslateText(translator); 
        DTAIConfig.TranslateText(translator); 
        DTUnitConfig.TranslateText(translator); 
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}