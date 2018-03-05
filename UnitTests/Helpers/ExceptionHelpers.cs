using System;

namespace UnitTests.Helpers
{
    internal class ExceptionHelpers
    {
        internal static bool ExecuteSuccessfully(Action invoke)
        {
            try
            {
                invoke();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}