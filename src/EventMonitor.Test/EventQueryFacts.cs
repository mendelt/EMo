using System.Linq;
using EMo.Core;
using Xunit;

namespace EMo
{
    public class EventQueryFacts
    {
        [Fact]
        public void WithParamsFiltersNonMatchingEvents()
        {
            var query =
                new[]
                {
                    new RecordedEvent(3, 4, 5),
                    new RecordedEvent(3, 3, 5),
                    new RecordedEvent(3, 4, 5),
                };

            Assert.Equal(2, query.WithParams(3, 4, 5).Count());
        }
    }
}
