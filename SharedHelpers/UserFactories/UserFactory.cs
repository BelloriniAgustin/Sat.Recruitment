using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;

namespace Sat.Recruitment.Helpers.UserFactories
{
    public abstract class UserFactory
    {
        private static readonly IDictionary<string, UserFactory> _userTypeFactories = new Dictionary<string, UserFactory>()
            {
                { Constants.UserTypeNormal, new NormalFactory() },
                { Constants.UserTypeSuperUser, new SuperUserFactory() },
                { Constants.UserTypePremium, new PremiumFactory() }
            };

        public abstract User CreateConcreteUser(UserDTO user);

        public static User CreateUser(UserDTO user)
        {
            if (_userTypeFactories.TryGetValue(user.UserType, out var factory))
            {
                return factory.CreateConcreteUser(user);
            } 
            else
            {
                throw new ArgumentException(Constants.InvalidUserTypeMessage, user.UserType);
            }
        }
    }
}
