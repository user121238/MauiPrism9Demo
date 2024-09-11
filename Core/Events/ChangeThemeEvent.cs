using Core.Enums;

namespace Core.Events
{
    public class ChangeThemeEvent : PubSubEvent<ThemeKey>
    {
    }
}