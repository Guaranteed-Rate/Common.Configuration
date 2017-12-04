using System.Collections.Generic;

namespace GuaranteedRate.Common.Configuration
{
    /// <summary>
    /// Describes the ConfigWrapper class.  This interface is intended for use in dependency-injection scenarios.
    /// </summary>
    public interface IConfigWrapper
    {
        /// <summary>
        /// Attempts to get an app setting, returning a default if not found or not castable.
        /// </summary>
        /// <typeparam name="T">Type of the value you want</typeparam>
        /// <param name="key">Key Name e.g. "TimeoutValue" </param>
        /// <param name="defaultValue">If not found or wrong type, what should we use?</param>
        /// <param name="errorOnWrongType">Blow up if it won't cast cleanly.</param>
        /// <returns>value of type T, either the value from app.config/web.config or defaultValue.</returns>
        T GetAppSetting<T>(string key, T defaultValue, bool errorOnWrongType = false);

        /// <summary>
        /// Attempts to get an app setting, returning a default if not found or not castable.
        /// </summary>
        /// <typeparam name="T">Type of the value you want</typeparam>
        /// <param name="key">Key Name e.g. "TimeoutValue" </param>
        /// <param name="defaultValue">If not found or wrong type, what should we use?</param>
        /// <param name="delimiter">how should we parse the values, e.g. new [] {',','|'}</param>
        /// <returns>value of type T, either the value from app.config/web.config or defaultValue.</returns>
        IEnumerable<T> GetAppSetting<T>(string key, IEnumerable<T> defaultValue, char[] delimiter);
    }
}
