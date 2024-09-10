using Core.Abstracts;
using Serilog;

namespace UI
{
    public class UiAppContext : IAppContext
    {
        #region Implementation of IAppContext

        /// <summary>
        /// 默认设置
        /// </summary>
        public IPreferences DefaultSettings => Preferences.Default;

        /// <summary>
        /// 日志
        /// </summary>
        public ILogger Logger => Log.Logger;

        #endregion
    }
}