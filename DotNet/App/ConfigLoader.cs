using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Bright.Serialization;
using SimpleJSON;

namespace ET.Server
{
    [Invoke]
    public class LubanLoadAllAsyncHandler : AInvokeHandler<ConfigComponent.LoadAll, ETTask>
    {
        public override async ETTask Handle(ConfigComponent.LoadAll arg)
        {
            Type tablesType = typeof (Tables);

            MethodInfo loadMethodInfo = tablesType.GetMethod("LoadAsync");

            Type loaderReturnType = loadMethodInfo.GetParameters()[0].ParameterType.GetGenericArguments()[1];
            
            // 根据cfg.Tables的构造函数的Loader的返回值类型决定使用json还是ByteBuf Loader
            if (loaderReturnType == typeof (Task<ByteBuf>))
            {
                async Task<ByteBuf> LoadByteBuf(string file)
                {
                    return new ByteBuf(await File.ReadAllBytesAsync(GetLubanAssetPath(file, false)));
                }

                Func<string, Task<ByteBuf>> func = LoadByteBuf;
                await (Task)loadMethodInfo.Invoke(Tables.Instance, new object[] { func });
            }
            else
            {
                async Task<JSONNode> LoadJson(string file)
                {
                    return JSON.Parse(await File.ReadAllTextAsync(GetLubanAssetPath(file, true)));
                }

                Func<string, Task<JSONNode>> func = LoadJson;
                await (ETTask)loadMethodInfo.Invoke(Tables.Instance, new object[] { func });
            }
        }
        
        private string GetLubanAssetPath(string fileName, bool isJson)
        {
            if (isJson)
            {
                return $"../Config/Luban/{fileName}.json";
            }

            return $"../Config/Luban/{fileName}.byte";
        }
    }
    
    [Invoke]
    public class LubanLoadOneAsyncHandler: AInvokeHandler<ConfigComponent.LoadOne, ETTask>
    {
        public override async ETTask Handle(ConfigComponent.LoadOne arg)
        {
            await Tables.Instance.GetDataTable(arg.ConfigName).LoadAsync();
        }
    }
}