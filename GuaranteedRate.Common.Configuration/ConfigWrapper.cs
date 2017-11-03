namespace GuaranteedRate.Common.Configuration
{
    /// <summary>
    /// This class that just wraps the helper functions found in ConfigHelpers.
    /// This class exists so we can make another project use the IConfigWrapper interface and inject either this class or a Mock at runtime.
    /// </summary>
    public class ConfigWrapper : IConfigWrapper
    {

        /// <summary>
        /// attempts to get an app setting, returning a default if not found or not castable.
        /// </summary>
        /// <typeparam name="T">Type of the value you want</typeparam>
        /// <param name="key">Key Name e.g. "TimeoutValue" </param>
        /// <param name="defaultValue">if not found or wrong type, what should we use?</param>
        /// <param name="errorOnWrongType">blow up if it won't cast cleanly</param>
        /// <returns>T</returns>
        public T GetAppSetting<T>(string key, T defaultValue, bool errorOnWrongType = false)
        {
            return ConfigHelper.GetAppSetting<T>(key, defaultValue, errorOnWrongType);
        }
    }
}
