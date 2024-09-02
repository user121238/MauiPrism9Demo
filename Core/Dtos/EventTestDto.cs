using Core.Abstracts;

namespace Core.Dtos
{
    public class EventTestDto : IEventTest
    {
        #region Implementation of IEventTest

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public EventTestDto(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; set; }
        public string Content { get; set; }

        #endregion
    }
}
