using System;
using System.Collections.Generic;
using System.Linq;

namespace GuaranteedRate.Common.Configuration
{
    public static class ConfigHelper
    {
        /// <summary>
        /// Attempts to get an app setting, returning a default if not found or not castable.
        /// </summary>
        /// <typeparam name="T">Type of the value you want</typeparam>
        /// <param name="key">Key Name e.g. "TimeoutValue" </param>
        /// <param name="defaultValue">If not found or wrong type, what should we use?</param>
        /// <param name="errorOnWrongType">Blow up if it won't cast cleanly.</param>
        /// <returns>value of type T, either the value from app.config/web.config or defaultValue.</returns>
        public static T GetAppSetting<T>(string key, T defaultValue, bool errorOnWrongType = false)
        {
            var result = System.Configuration.ConfigurationManager.AppSettings.Get(key);
            if (string.IsNullOrEmpty(result))
            {
                return defaultValue;
            }

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

                return defaultValue;
            }
        }
        /// <summary>
        /// Always errors if types cannot be cast.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static  IEnumerable<T> GetAppSetting<T>(string key, IEnumerable<T> defaultValue, char[] delimiter )
        {
            var value = GetAppSetting(key, string.Empty);
            var values = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<T>();
            foreach (var v in values)
            {
                try
                {
                    result.Add((T)Convert.ChangeType(result, typeof(T)));
                }
                 
                catch (Exception)
                {
                     
                        throw new Exception(string.Format("Problem fetching {0} as {1}.  It's a {2}", key, typeof(T).Name,
                            result.GetType().Name));
                     

                }
            }
            if (result.Any())
            {
                return result;
            }
            return defaultValue;
        }


    }
}