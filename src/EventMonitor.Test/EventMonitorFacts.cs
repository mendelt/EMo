using System;
using EMo.Core;
using Xunit;

namespace EMo
{
    public class EventMonitorFacts
    {
        private EventSource eventSource = new EventSource();

        [Fact]
        public void RegistersSpecifiedEvent()
        {
            Assert.NotNull(eventSource.Monitor());
        }

        [Fact]
        public void EventReturnsOneEventrecorderInIenumerable()
        {
            var object1 = new object();
            var events = new[] {new EventRecorder(object1, "eventname"), new EventRecorder(null,"")};

            Assert.Equal(events[0], events.Event( "eventname"));
        }

        [Fact]
        public void CannotGetRecorderForNullObject()
        {
            var eventList = eventSource.Monitor();

            Assert.Throws<InvalidOperationException>(() => eventList.Event("NullEvent"));
        }

        [Fact]
        public void CanRegisterMultipleEvents()
        {
            eventSource.Monitor();

            Assert.NotNull(eventSource.Raised().Event("SimpleEvent"));
            Assert.NotNull(eventSource.Raised().Event("ParameterLessEvent"));
            Assert.NotNull(eventSource.Raised().Event("WeirdEvent"));
        }
    }
}
