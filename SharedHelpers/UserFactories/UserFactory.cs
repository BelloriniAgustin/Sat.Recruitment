using Sat.Recruitment.Entities;
using System;

namespace Sat.Recruitment.Helpers.UserFactories
{
    public abstract class UserFactory
    {
        public abstract User CreateConcreteUser(UserDTO user);

        public static User CreateUser(UserDTO user)
        {
            return user.UserType switch
            {
                Constants.UserTypeNormal => new NormalFactory().CreateConcreteUser(user),
                Constants.UserTypeSuperUser => new SuperUserFactory().CreateConcreteUser(user),
                Constants.UserTypePremium => new PremiumFactory().CreateConcreteUser(user),
                _ => throw new ArgumentException("Invalid type", user.UserType),
            };
        }
    }
}
