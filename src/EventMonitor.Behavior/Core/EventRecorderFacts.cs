using System.Linq;
using Xunit;

namespace EMo.Core
{
    public class EventRecorderFacts
    {
        [Fact]
        public void Should_Register_Event()
        {
            var recorder = new EventRecorder(this, string.Empty);

            recorder.RecordEvent();

            Assert.Equal(1, recorder.Count());
        }

        [Fact]
        public void Should_Register_Multiple_Events()
        {
            var recorder = new EventRecorder(this, string.Empty);

            recorder.RecordEvent();
            recorder.RecordEvent();

            Assert.Equal(2, recorder.Count());
        }

        [Fact]
        public void Should_Register_Events_Parameters()
        {
            var recorder = new EventRecorder(this, string.Empty);

            recorder.RecordEvent(3, 8, "some info");

            Assert.Equal(3, recorder.ElementAt(0).Parameters[0]);
            Assert.Equal(8, recorder.ElementAt(0).Parameters[1]);
            Assert.Equal("some info", recorder.ElementAt(0).Parameters[2]);

        }
    }
}