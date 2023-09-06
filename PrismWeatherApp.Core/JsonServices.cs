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
        public static T LoadJson<T>(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException();
            }
            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                T result = JsonConvert.DeserializeObject<T>(json);
                if (result != null)
                {
                    return result;
                }
                throw new NullReferenceException();
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
