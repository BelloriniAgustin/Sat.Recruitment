using Sat.Recruitment.Entities;

namespace Sat.Recruitment.Helpers.UserFactory
{
    public class PremiumFactory : UserFactory
    {
        public override User CreateUser(string name, string email, string phone, string address, string userType, decimal money)
        {
            return new Premium() 
            {
                Name = name,
                Email = email,
                Phone = phone,
                Address = address,
                UserType = userType,
                Money = money
            };
        }
    }
}
