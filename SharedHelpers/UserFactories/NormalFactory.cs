using Sat.Recruitment.Entities;

namespace Sat.Recruitment.Helpers.UserFactory
{
    public class NormalFactory : UserFactory
    {
        public override User CreateUser(string name, string email, string phone, string address, string userType, decimal money)
        {
            return new Normal()
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
