using System.Linq;
using Xunit;

namespace EMo.Examples
{
    public class EventMonitorExamples
    {
        readonly ExampleEventSource eventSource;

        public EventMonitorExamples()
        {
            eventSource = new ExampleEventSource();
        }

        /// <summary>
        /// This is how things used to be done, pretty clean but not very readable and things get even
        /// less readable for more complicated cases
        /// </summary>
        [Fact]
        public void WithoutEMo()
        {
            var raised = 0;
            eventSource.NormalEvent += (sender, args) => raised++;

            eventSource.InvokeNormalEvent(null);

            Assert.True(raised > 0);
        }

        /// <summary>
        /// This example shows how to catch and assert a single event with EMo, this is a lot more readable
        /// </summary>
        [Fact]
        public void NormalUsage()
        {
            eventSource.Monitor();

            eventSource.InvokeNormalEvent(null);

            Assert.True(eventSource.Raised().Event("NormalEvent").Any());
        }

        /// <summary>
        /// And things are still readable for more complex cases. try this with lambda's
        /// </summary>
        [Fact]
        public void MoreComplicatedAssert()
        {
            eventSource.Monitor();

            eventSource.InvokeNormalEvent(null);
            eventSource.InvokeNormalEvent(null);
            
            Assert.Equal(2, eventSource.Raised().Event("NormalEvent").WithParams(eventSource, null).Count());
        }
    }
}