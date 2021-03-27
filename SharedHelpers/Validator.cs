using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;

namespace Sat.Recruitment.Helpers
{
    public static class Validator
    {
        public static bool IsValidUser(string name, string email, string address, string phone, ref string errors)
        {
            if (name == null)
                //Validate if Name is null
                errors = "The name is required";
                return false;
            if (email == null)
                //Validate if Email is null
                errors = errors + " The email is required";
                return false;
            if (address == null)
                //Validate if Address is null
                errors = errors + " The address is required";
                return false;
            if (phone == null)
                //Validate if Phone is null
                errors = errors + " The phone is required";
                return false;
            return true;
        }

        public static bool IsDuplicatedUser(string name, string email, string address, string phone, List<User> users, ref string errors)
        {
            foreach (var user in users)
            {
                if (user.Email == email
                    ||
                    user.Phone == phone)
                {
                    errors = "User is duplicated";
                    return true;
                }
                else if (user.Name == name)
                {
                    if (user.Address == address)
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
