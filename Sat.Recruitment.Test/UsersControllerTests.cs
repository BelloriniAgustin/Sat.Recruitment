using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Entities;
using System.Net;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerTests
    {
        private readonly UsersController _usersController = new UsersController();
        private const string SchemaValidatorMinNameLength = "String '' is less than minimum length of 1. Path 'Name'.";
        private const string InvalidTypeArgException = "Invalid type (Parameter 'InvalidType')";

        [Theory]
        [InlineData(Constants.UserTypePremium, 50, "50")]
        [InlineData(Constants.UserTypePremium, 124, "372")]
        [InlineData(Constants.UserTypeNormal, 50, "90.0")]
        [InlineData(Constants.UserTypeNormal, 5, "5")]
        [InlineData(Constants.UserTypeNormal, 124, "138.88")]
        [InlineData(Constants.UserTypeSuperUser, 124, "148.8")]
        [InlineData(Constants.UserTypeSuperUser, 50, "50")]
        public void CreateUserReturnsOkTheory(string userType, decimal money, string expectedMoney)
        {
            // Arrange
            var user = GetUserDTO(userType, money);

            // Act
            var result = _usersController.CreateUser(user);

            // Assert
            AssertApiResponse(result, HttpStatusCode.OK, string.Format(Constants.SuccessUserCreationMessage, expectedMoney));
        }

        [Fact]
        public void CreateDuplicatedUserReturnsBadRequest()
        {
            // Arrange
            var user = new UserDTO
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Garay y Otra Calle",
                Phone = "+534645213542",
                UserType = "SuperUser",
                Money = 112234
            };

            // Act
            var result = _usersController.CreateUser(user);

            // Assert
            AssertApiResponse(result, HttpStatusCode.BadRequest, Constants.DuplicatedUserErrorMessage);
        }

        [Fact]
        public void CreateInvalidUserPropertiesReturnsBadRequest()
        {
            // Arrange
            var user = GetUserDTO("Normal", 124, "");

            // Act
            var result = _usersController.CreateUser(user);

            // Assert
            AssertApiResponse(result, HttpStatusCode.BadRequest, SchemaValidatorMinNameLength);
        }

        [Fact]
        public void CreateInvalidUserTypeReturnsServerError()
        {
            // Arrange
            var user = GetUserDTO("InvalidType", 124);

            // Act
            var result = _usersController.CreateUser(user);

            // Assert
            AssertApiResponse(result, HttpStatusCode.InternalServerError, InvalidTypeArgException);
        }
        
        private static UserDTO GetUserDTO(string userType, decimal money, string name = "Mike")
        {
            return new UserDTO
            {
                Name = name,
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = userType,
                Money = money
            };
        }

        private static void AssertApiResponse(ApiResponse result, HttpStatusCode statusCode, string message)
        {
            Assert.Equal(statusCode, result.StatusCode);
            Assert.Equal(message, result.Message);
        }
    }
}
