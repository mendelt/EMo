using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMo
{
    public class ContextBase : IDisposable
    {
        public ContextBase()
        {
            try { Context(); }
            catch (Exception ex) { Console.Write(ex.ToString()); }

            try { When(); }
            catch (Exception ex) { Console.Write(ex.ToString()); }
        }

        public void Dispose()
        {
            CleanUp();
        }

        public virtual void CleanUp() { }
        public virtual void Context() { }
        public virtual void When() { }
    }
}

