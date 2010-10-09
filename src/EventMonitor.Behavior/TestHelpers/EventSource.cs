using System;

namespace EMo
{
    /// <summary>
    /// Test helper class to simulate raising events
    /// </summary>
    public class EventSource
    {
        /// <summary>
        /// Basic event based on normal eventhandler as perscribed by microsoft
        /// </summary>
        public event EventHandler SimpleEvent;

        public void InvokeSimpleEvent()
        {
            var handler = SimpleEvent;
            if (handler != null) handler(this, new EventArgs());
        }

        /// <summary>
        /// Event without any parameters, I use these a lot as I don't like the EventHandler and arguments stuff
        /// </summary>
        public event Action ParameterLessEvent;

        public void InvokeParameterLessEvent()
        {
            var parameterLessEventAction = ParameterLessEvent;
            if (parameterLessEventAction != null) parameterLessEventAction();
        }

        /// <summary>
        /// Weird event with all kinds of non-standard parameters
        /// </summary>
        public event Action<int, int, string> WeirdEvent;

        public void InvokeWeirdEvent(int arg1, int arg2, string arg3)
        {
            var weirdEventAction = WeirdEvent;
            if (weirdEventAction != null) weirdEventAction(arg1, arg2, arg3);
        }
    }
}
