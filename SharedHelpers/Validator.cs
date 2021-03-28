using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Sat.Recruitment.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Helpers
{
    public static class Validator
    {
        public static bool IsValidUser(UserDTO user, IList<UserDTO> users, ref string errors)
        {
            return UserHasValidProperties(user, ref errors) && !IsDuplicatedUser(user, users, ref errors);
        }

        public static bool UserHasValidProperties(UserDTO userDTO, ref string errors)
        {
            var userSchema = Utils.ReadFile(Constants.UsersJsonSchemaPath);
            var user = JObject.FromObject(userDTO);

            if (!user.IsValid(JSchema.Parse(userSchema), out IList<string> errorMessages))
            {
                errors = string.Join(", ", errorMessages);
                return false;
            }

            userDTO.Email = Utils.NormalizeEmail(userDTO.Email);

            return true;
        }

        public static bool IsDuplicatedUser(UserDTO newUser, IList<UserDTO> users, ref string errors)
        {
            if (users.Any(user => user.Equals(newUser)))
            {
                errors = Constants.DuplicatedUserErrorMessage;
                return true;
            }

            return false;
        }
    }
}
