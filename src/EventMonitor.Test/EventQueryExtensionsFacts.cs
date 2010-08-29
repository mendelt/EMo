using EMo.Core;
using Xunit;

namespace EMo
{
    public class QueryHelperFacts
    {
        [Fact]
        public void ParametersMatchShouldMatchForSameParameters()
        {
            var reference = new object();
            var recEvent = new RecordedEvent(1, 2.0f, reference);

            recEvent.ParametersMatch(1, 2.0f, reference);
        }

        [Fact]
        public void AreMatchShouldMatchBoxedValuetypes()
        {
            Assert.True(QueryHelpers.AreMatch(3, 3));
        }

        [Fact]
        public void AreMatchShouldFailWithDifferentBoxedValuetypes()
        {
            Assert.False(QueryHelpers.AreMatch(3, 4));
        }

        [Fact]
        public void AreMatchShouldFailWithDifferentReferences()
        {
            var value1 = new object();
            var value2 = new object();

            Assert.False(QueryHelpers.AreMatch(value1, value2));
        }

        [Fact]
        public void AreMatchShouldMatchReferences()
        {
            var value1 = new object();
            var value2 = value1;

            Assert.True(QueryHelpers.AreMatch(value1, value2));
        }

        [Fact]
        public void AreMatchShouldMatchNullReferences()
        {
            Assert.True(QueryHelpers.AreMatch(null, null));
        }

        [Fact]
        public void AreMatchShouldFailWithNullAndObjectReference()
        {
            var value1 = new object();
            object value2 = null;

            Assert.False(QueryHelpers.AreMatch(value1, value2));
        }
    }
}