using Newtonsoft.Json;
using System.Diagnostics;

namespace PrismWeatherApp.Core
{
    public static class JsonServices
    {
        public static bool SaveJson(object obj)
        {
            try
            {
                if (obj == null)
                {
                    throw new ArgumentNullException();
                }
                string json = JsonConvert.SerializeObject(obj);
                System.IO.File.WriteAllText("CurrentLoc.json", json);
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
