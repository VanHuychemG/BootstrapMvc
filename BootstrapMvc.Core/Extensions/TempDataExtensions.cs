using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Newtonsoft.Json;

namespace BootstrapMvc.Core.Extensions
{
    public static class TempDataExtensions
    {
        public static void SetAsJson<T>(this ITempDataDictionary tempData, string key, T data)
        {
            var sData = JsonConvert.SerializeObject(data);

            tempData[key] = sData;
        }

        public static T GetFromJson<T>(this ITempDataDictionary tempData, string key)
        {
            if (!tempData.ContainsKey(key))
                return default(T);

            var v = tempData[key];

            if (v is T)
                return (T)v;

            if (!(v is string) || typeof(T) == typeof(string))
                return default(T);

            return JsonConvert.DeserializeObject<T>((string)v);
        }
    }
}
