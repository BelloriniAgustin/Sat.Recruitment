using Sat.Recruitment.Entities;

namespace Sat.Recruitment.Helpers.UserFactories
{
    public class PremiumFactory : UserFactory
    {
        public override User CreateConcreteUser(UserDTO user)
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
