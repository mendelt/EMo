using Xunit;
using Moq;

namespace EMo.Core
{
    public class EventSubscriberFacts
    {
        private delegate void SimpleDelegate();

        [Fact]
        public void CanCodeGenDelegate()
        {
            var recorder = new EventRecorder(this, "test");
            var testHandler = EventSubscriber.GenerateHandler(typeof(SimpleDelegate), recorder) as SimpleDelegate;

            Assert.NotNull(testHandler);
        }

        [Fact]
        public void GeneratedDelegateCallsRecorderRegisterEvent()
        {
            var recorderMock = new Mock<IEventRecorder>();
            var testHandler = EventSubscriber.GenerateHandler(typeof(SimpleDelegate), recorderMock.Object) as SimpleDelegate;

            testHandler();

            recorderMock.Verify( x => x.RecordEvent( ), Times.Once( ) );
        }

        public delegate void DelegateWithParameters(int i, string s);

        [Fact]
        public void GeneratedDelegatePassesParametersToEventrecorder()
        {
            var recorderMock = new Mock<IEventRecorder>();
            var testHandler = EventSubscriber.GenerateHandler(typeof(DelegateWithParameters), recorderMock.Object) as DelegateWithParameters;

            testHandler(3, "this is a string");

            recorderMock.Verify( x => x.RecordEvent( 3, "this is a string" ), Times.Once( ) );
        }
    }
}
