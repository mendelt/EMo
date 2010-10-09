using System;
using Xunit;

namespace EMo
{
    public class WhenRegisteringEventMonitorOnEventLessObject : EventMonitorContext.EventMonitorContext
    {
        [Fact]
        public void ShouldThrowInvalidOperationException()
        {
            Assert.Throws < InvalidOperationException>( ( ) => ( new object() ).Monitor( ) );
        }
    }
}