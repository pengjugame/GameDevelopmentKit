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
   
public partial class DTMusic
{
    private readonly Dictionary<int, DRMusic> _dataMap;
    private readonly List<DRMusic> _dataList;
    
    public DTMusic(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, DRMusic>();
        _dataList = new List<DRMusic>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            DRMusic _v;
            _v = DRMusic.DeserializeDRMusic(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, DRMusic> DataMap => _dataMap;
    public List<DRMusic> DataList => _dataList;

    public DRMusic GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public DRMusic Get(int key) => _dataMap[key];
    public DRMusic this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}