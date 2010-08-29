using System.Collections.Generic;
using System.Linq;
using EMo.Core;

namespace EMo
{
    /// <summary>
    /// Extension methods for filtering recorded events
    /// </summary>
    public static class EventQueryExtensions
    {
        /// <summary>
        /// Limits a query to only recorded events with certain parameters.
        /// </summary>
        public static IEnumerable<RecordedEvent> WithParams(this IEnumerable<RecordedEvent> events, params object[] parameters)
        {
            foreach (var recordedEvent in events)
            {
                if (recordedEvent.ParametersMatch(parameters)) yield return recordedEvent;
            }
        }
    }
}