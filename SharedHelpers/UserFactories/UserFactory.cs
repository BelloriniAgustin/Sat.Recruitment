using Sat.Recruitment.Entities;

namespace Sat.Recruitment.Helpers.UserFactory
{
    public abstract class UserFactory
    {
        public abstract User CreateUser(UserDTO user);
    }
}
