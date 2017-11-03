using System;
using System.Collections.Generic;

namespace GuaranteedRate.Common.Configuration
{
    public static class DictionaryHelper
    {
        public static T GetValue<T>(this Dictionary<string, string> dict, string key, T @default,
            bool errorOnWrongType = false)
        {
            if (!dict.ContainsKey(key))
            {
                return @default;
            }
            var result = dict[key];
            return CastConvertAndReturn(result, @default, errorOnWrongType, key);

        }

        private static T CastConvertAndReturn<T>(object result, T @default, bool errorOnWrongType, string key)
        {
            if (result is T)
            {
                return (T) Convert.ChangeType(result, typeof(T));
            }
            //try casting anyway...
            try
            {
                return (T) Convert.ChangeType(result, typeof(T));
            }
            catch (Exception)
            {
                if (errorOnWrongType)
                {
                    throw new Exception(string.Format("Problem fetching {0} as {1}.  It's a {2}", key, typeof(T).Name,
                        result.GetType().Name));
                }

                return @default;
            }

        }

        public static T GetValue<T>(this Dictionary<string, object> dict, string key, T @default,
            bool errorOnWrongType = false)
        {
            if (!dict.ContainsKey(key))
            {
                return @default;
            }
            var result = dict[key];

            return CastConvertAndReturn(result, @default, errorOnWrongType, key);

        }
    }
}
