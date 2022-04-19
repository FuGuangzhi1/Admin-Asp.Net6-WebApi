using Newtonsoft.Json;

namespace Common_Fu;

public static partial class Extension
{
    public static string ObjectToJson(this object obj)
    {
        JsonSerializerSettings setting = new();
        setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        var json = JsonConvert.SerializeObject(obj, setting);
        return json;
    }
    public static T? ToJson<T>(this string jsonString)
      => JsonConvert.DeserializeObject<T>(jsonString);

}
