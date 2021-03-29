using System;

namespace Sat.Recruitment.Helpers.Exceptions
{
    public class UsersFileHelperExceptions : Exception
    {
        public UsersFileHelperExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
