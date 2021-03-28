using System;

namespace Sat.Recruitment.Helpers.Exceptions
{
    public class UtilsExceptions : Exception
    {
        public UtilsExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
