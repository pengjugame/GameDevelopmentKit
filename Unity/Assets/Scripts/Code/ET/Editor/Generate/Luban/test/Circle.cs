//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace ET.Editor.test
{

/// <summary>
/// 这是一个圆
/// </summary>
public sealed partial class Circle :  Shape 
{
    public Circle()
    {
    }

    public override void LoadJson(SimpleJSON.JSONObject _json)
    {
        { 
            var _fieldJson = _json["radius"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsNumber) { throw new SerializationException(); }  Radius = _fieldJson;
            }
        }
        
    }

    public override void SaveJson(SimpleJSON.JSONObject _json)
    {
        _json["$type"] = "test.Circle";
        {
            _json["radius"] = new JSONNumber(Radius);
        }
    }

    public static Circle LoadJsonCircle(SimpleJSON.JSONNode _json)
    {
        Circle obj = new test.Circle();
        obj.LoadJson((SimpleJSON.JSONObject)_json);
        return obj;
    }
        
    public static void SaveJsonCircle(Circle _obj, SimpleJSON.JSONNode _json)
    {
        _obj.SaveJson((SimpleJSON.JSONObject)_json);
    }

    /// <summary>
    /// 半径
    /// </summary>
    public float Radius { get; set; }

}

}