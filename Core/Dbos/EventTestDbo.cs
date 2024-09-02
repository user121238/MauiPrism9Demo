using Core.Abstracts;

namespace Core.Dbos
{
    public class EventTestDbo : IEventTest
    {
        #region Implementation of ITest

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public EventTestDbo(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; set; }
        public string Content { get; set; }

        #endregion
    }
}