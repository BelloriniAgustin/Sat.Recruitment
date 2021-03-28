using Sat.Recruitment.Entities;

namespace Sat.Recruitment.Helpers.UserFactory
{
    public class PremiumFactory : UserFactory
    {
        public override User CreateUser(UserDTO user)
        {
            return new Premium() 
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
