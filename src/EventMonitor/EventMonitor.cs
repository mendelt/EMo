using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EMo.Core;

namespace EMo
{
    /// <summary>
    /// Provides extension methods for monitoring and querying events.
    /// </summary>
    public static class EventMonitor
    {
        private static IDictionary<Object, IList<IEventRecorder>> eventRecorders = new Dictionary<Object, IList<IEventRecorder>>();

        /// <summary>
        /// Starts monitoring events on an object.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if eventSource is Null.</exception>
        public static IEnumerable<IEventRecorder> Monitor(this object eventSource)
        {
            if (eventSource == null) throw new ArgumentNullException(string.Format("Error starting event monitoring. eventSource cannot be null."));
            
            // Find all events
            var recorders = new List<IEventRecorder>();

            foreach (var @event in eventSource.GetType().GetEvents())
            {
                recorders.Add(Monitor(eventSource, @event));
            }

            if (!recorders.Any()) throw new InvalidOperationException(string.Format("Error starting event monitoring. Object {0} does not expose any events.", eventSource));

            if (eventRecorders.ContainsKey(eventSource)) eventRecorders.Remove(eventSource);
            eventRecorders.Add(eventSource, recorders);

            return recorders;
        }

        /// <summary>
        /// Creates an Event Handler for the EventInfo Passed to Hook it the Event Up to an Event Recorder.
        /// </summary>
        private static EventRecorder Monitor(object eventSource, EventInfo eventInfo)
        {
            // Create EventRecorder
            var eventRecorder = new EventRecorder(eventSource, eventInfo.Name);

            // Subscribe EventRecorder to event
            var handler = EventSubscriber.GenerateHandler(eventInfo.EventHandlerType, eventRecorder);
            eventInfo.AddEventHandler(eventSource, handler);

            return eventRecorder;
        }

        /// <summary>
        /// Return all IEventRecorders registered for an object.
        /// </summary>
        public static IEnumerable<IEventRecorder> Raised(this object eventSource)
        {
            if (!eventRecorders.ContainsKey(eventSource)) throw new InvalidOperationException(string.Format("Object {0} is not being monitored for events. Use the Monitor() extension method to start monitoring events.", eventSource));

            return eventRecorders[eventSource];
        }

        /// <summary>
        /// Returns a single eventrecorder from a list that can then be queried
        /// </summary>
        public static IEventRecorder Event(this IEnumerable<IEventRecorder> recorders, string eventName)
        {
            var events = from recorder in recorders where recorder.EventName == eventName select recorder;

            if(! events.Any()) throw new InvalidOperationException(string.Format("No events found with name {0}", eventName));

            return events.Single();
        }
    }
}
