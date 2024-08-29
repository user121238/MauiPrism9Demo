namespace Core.Attributes
{
    /// <summary>
    /// 注入视图模型到区域导航
    /// </summary>
    /// <param name="viewModelType"></param>
    /// <param name="registerName"></param>
    [AttributeUsage(AttributeTargets.Class)]
    public class IocForRegionNavigationAttribute(Type viewModelType, string? registerName = null) : Attribute
    {
        /// <summary>
        /// ViewModel类型
        /// </summary>
        public Type ViewModelType { get; set; } = viewModelType;

        /// <summary>
        /// 注册名称
        /// </summary>
        public string? RegisterName { get; set; } = registerName;
    }
}