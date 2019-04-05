using Newtonsoft.Json;
using System;

namespace Initium
{
    public static class StringExtension
    {
        public static T Deserialize<T>(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
