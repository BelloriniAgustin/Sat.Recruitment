using Sat.Recruitment.Entities;

namespace Sat.Recruitment.Helpers.UserFactory
{
    public class SuperUserFactory : UserFactory
    {
        public override User CreateUser(UserDTO user)
        {
            return new SuperUser()
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                UserType = user.UserType,
                Money = user.Money
            };
        }
    }
}
