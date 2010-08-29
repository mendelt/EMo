using System;
using Xunit;

namespace EMo.EventMonitorContext
{
    public class WhenRegisteringEventMonitorOnNullObject: EventMonitorContext
    {
        [Fact]
        public void ShouldThrowArgumentNullException()
        {
            object nullObject = null;
            Assert.Throws<ArgumentNullException>(() => nullObject.Monitor());
        }
    }
}