using Microsoft.AspNetCore.Authentication;

namespace GhazaSystem.UI.Shared
{
    public class ReportUrlApi
    {
        public string baseurl = "http://localhost:8000/";
        public const string inday =  "api/Report/inday";
        public const string selectmont = "api/Report/mont";
        public static string getinday(DateTime day)
        {
            var dat = day.ToString();
            var url = dat.Replace("/", "-");
            return "http://localhost:8000/" + inday +"/"+ url;
        }

        public static string getmont(int mont)
        {
            return "http://localhost:8000/" + selectmont + "/" + mont; 
        }
    }
}
