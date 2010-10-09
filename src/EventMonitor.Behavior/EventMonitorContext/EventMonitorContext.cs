using TestHelpers;

namespace EMo.EventMonitorContext
{
    public class EventMonitorContext : ContextBase
    {
        protected EventSource eventSource;

        public override void Given()
        {
            eventSource = new EventSource();
        }
    }
}