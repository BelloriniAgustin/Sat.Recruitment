﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Sat.Recruitment.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sat.Recruitment.Helpers
{
    public static class Validator
    {
        public static bool IsValidUser(UserDTO user, List<UserDTO> users, ref string errors)
        {
            return UserHasValidProperties(user, ref errors) && !IsDuplicatedUser(user, users, ref errors);
        }

        public static bool UserHasValidProperties(UserDTO userDTO, ref string errors)
        {
            var userSchema = Utils.ReadFile("/Files/UserSchema.json");
            var user = JObject.FromObject(userDTO);

            if (!user.IsValid(JSchema.Parse(userSchema), out IList<string> errorMessages))
            {
                errors = string.Join(", ", errorMessages);
                return false;
            }

            return true;
        }

        public static bool IsDuplicatedUser(UserDTO newUser, List<UserDTO> users, ref string errors)
        {
            if (users.Any(user => user.Equals(newUser)))
            {
                errors = "User is duplicated";
                return true;
            }

            return false;
        }
    }
}
