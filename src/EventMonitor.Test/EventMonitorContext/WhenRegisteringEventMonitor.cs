using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EMo.EventMonitorContext
{
    public class WhenRegisteringEventMonitor : EventMonitorContext
    {
        IEnumerable<IEventRecorder> eventRecorders;

        public override void When()
        {
            eventRecorders = eventSource.Monitor();
        }

        [Fact]
        public void ShouldHaveRegisteredAllEvents()
        {
            Assert.Equal(3, eventRecorders.Count());
        }
    }
}