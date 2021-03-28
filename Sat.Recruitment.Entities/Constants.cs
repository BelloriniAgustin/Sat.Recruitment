namespace Sat.Recruitment.Entities
{
    public class Constants
    {
        public const string SuccessUserCreationMessage = "User successfully created";

        public const string InvalidUserDefaultMessage = "Ivalid user";

        public const string DuplicatedUserErrorMessage = "User is duplicated";

        public const string InvalidUserTypeMessage = "Invalid type";

        public const string ErrorSavingNewUserMessage = "Error while saving new user";

        public const string ErrorReadingUsersFileMessage = "Error while reading users file";

        public const string NormalizeEmailErrorMessage = "Error trying to normalize email";

        public const string ReadFileErrorMessage = "Error trying to read file";

        public const string UserTypeNormal = "Normal";

        public const string UserTypeSuperUser = "SuperUser";

        public const string UserTypePremium = "Premium";

        public const string UsersFilePath = "/Files/Users.txt";

        public const string UsersJsonSchemaPath = "/Files/UserSchema.json";
    }
}
