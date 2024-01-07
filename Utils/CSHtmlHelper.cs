using Newtonsoft.Json;
namespace AnkaAUTH_Server.Utils;

public class CSHtmlHelper(){
    public static string GetVariable(dynamic variable){
        return JsonConvert.SerializeObject(variable);
    }
} 