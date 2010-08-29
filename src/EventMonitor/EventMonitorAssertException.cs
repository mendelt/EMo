using System;
using System.Text;

namespace EMo
{
    /// <summary>
    /// Exception thrown when an assertion fails in EMoTest
    /// </summary>
    public class EventMonitorAssertException : Exception
    {
        string Expected { get; set; }
        string Actual { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="expected">Expected to find</param>
        /// <param name="actual">Found</param>
        public EventMonitorAssertException(string expected, string actual)
        {
            Expected = expected;
            Actual = actual;
        }

        /// <summary>
        /// Error message for the exception
        /// </summary>
        public override string Message
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("\r\nEvent Monitor Assertion Failed:");
                sb.Append("Expected: ");
                sb.AppendLine(Expected);
                sb.Append("Actual: ");
                sb.AppendLine(Actual);
                return sb.ToString();
            }
        }
    }
}
