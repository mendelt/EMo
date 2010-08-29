using EMo.Core;

namespace EMo
{
    /// <summary>
    /// Collection of static helper methods hidden away in the query namespace so they
    /// don't clutter autocompletion for the user.
    /// </summary>
    public static class QueryHelpers
    {
        /// <summary>
        /// Compares event with a set of parameters.
        /// </summary>
        public static bool ParametersMatch(this RecordedEvent match, params object[] parameters)
        {
            if (match.Parameters.Length != parameters.Length) return false;

            for (var index = 0; index < parameters.Length; index++)
            {
                if (!AreMatch(match.Parameters[index], parameters[index])) return false;
            }

            return true;
        }

        /// <summary>
        /// Compares single parameter.
        /// </summary>
        public static bool AreMatch(object parameter, object match)
        {
            // If both are null they are equal, return true
            if (parameter == null && match == null) return true;

            // If only parameter is null they are not equal, return false
            if (parameter == null || match == null) return false;

            // If parameter is not null we can call Equals on it
            return (parameter.Equals(match));
        }
    }
}
