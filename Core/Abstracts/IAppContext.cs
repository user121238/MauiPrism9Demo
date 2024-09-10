using Serilog;

namespace Core.Abstracts
{
    /// <summary>
    /// App上下文
    /// </summary>
    public interface IAppContext
    {
        /// <summary>
        /// 默认设置
        /// </summary>
        IPreferences DefaultSettings { get; }

        ILogger Logger { get; }
    }
}