namespace GuaranteedRate.Common.Configuration
{
    /// <summary>
    /// Describes the ConfigWrapper class.  This interface is intended for use in dependency-injection scenarios
    /// </summary>
    public interface IConfigWrapper
    {
        /// <summary>
        /// attempts to get an app setting, returning a default if not found or not castable.
        /// </summary>
        /// <typeparam name="T">Type of the value you want</typeparam>
        /// <param name="key">Key Name e.g. "TimeoutValue" </param>
        /// <param name="defaultValue">if not found or wrong type, what should we use?</param>
        /// <param name="errorOnWrongType">blow up if it won't cast cleanly</param>
        /// <returns>T</returns>
        T GetAppSetting<T>(string key, T defaultValue, bool errorOnWrongType = false);
    }
}
