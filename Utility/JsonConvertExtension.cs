using Newtonsoft.Json;
using System;

namespace Utility
{
    public static class JsonConvertExtension
    {
        public static bool TryDeserializeObject(string value, out object data)
        {
            try
            {
                data = JsonConvert.DeserializeObject(value);
                return true;
            }
            catch (Exception)
            {
                data = null;
                return false;
            }
        }

        public static bool TryDeserializeObject(string value)
        {
            try
            {
                JsonConvert.DeserializeObject(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static object DeserializeObject(string value)
        {
            return JsonConvert.DeserializeObject(value);
        }

        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
