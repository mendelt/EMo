namespace EMo.EventMonitorContext
{
    public class EventMonitorContext : ContextBase
    {
        protected EventSource eventSource;

        public override void Context()
        {
            eventSource = new EventSource();
        }
    }
}