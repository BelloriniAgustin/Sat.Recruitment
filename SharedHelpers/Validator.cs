using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;

namespace Sat.Recruitment.Helpers
{
    public static class Validator
    {
        public static bool IsValidUser(User user, ref string errors)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                //Validate if Name is null
                errors = "The name is required";
                return false;
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                //Validate if Email is null
                errors = " The email is required";
                return false;
            }
            if (string.IsNullOrEmpty(user.Address))
            {
                //Validate if Address is null
                errors = " The address is required";
                return false;
            }
            if (string.IsNullOrEmpty(user.Phone))
            {
                //Validate if Phone is null
                errors = " The phone is required";
                return false;
            }

            return true;
        }

        public static bool IsDuplicatedUser(User newUser, List<User> users, ref string errors)
        {
            foreach (var user in users)
            {
                if (user.Email == Utils.NormalizeEmail(newUser.Email)
                    ||
                    user.Phone == newUser.Phone)
                {
                    errors = "User is duplicated";
                    return true;
                }
                else if (user.Name == newUser.Name)
                {
                    if (user.Address == newUser.Address)
                    {
                        errors = "User is duplicated";

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
