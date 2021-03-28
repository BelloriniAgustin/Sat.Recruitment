using Sat.Recruitment.Entities;

namespace Sat.Recruitment.Helpers.UserFactory
{
    public abstract class UserFactory
    {
        public abstract User CreateUser(string name, string email, string phone, string address, string userType, decimal money);
    }
}
