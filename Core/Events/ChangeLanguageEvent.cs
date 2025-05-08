using Core.Enums;

namespace Core.Events
{
    public class ChangeLanguageEvent : PubSubEvent<LanguageKey>
    {
    }
}