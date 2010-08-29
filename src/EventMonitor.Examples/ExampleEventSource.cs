using System;

namespace EMo.Examples
{
    public class ExampleEventSource
    {
        public event EventHandler NormalEvent;

        public void InvokeNormalEvent(EventArgs e)
        {
            var handler = NormalEvent;
            if(handler != null) handler(this, e);
        }
    }
}