using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Entities;
using System.Net;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerTests
    {
        private const string SchemaValidatorMinNameLength = "String '' is less than minimum length of 1. Path 'Name'.";
        private const string InvalidTypeArgException = "Invalid type (Parameter 'InvalidType')";

        [Fact]
        public void ShouldCreateNormalUser()
        {
            var userController = new UsersController();
            var user = new UserDTO
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            var result = userController.CreateUser(user);

            AssertApiResponse(result, HttpStatusCode.OK, Constants.SuccessUserCreationMessage);
        }

        [Fact]
        public void ShouldCreatePremiumUser()
        {
            var userController = new UsersController();
            var user = new UserDTO
            {
                Name = "Test",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Premium",
                Money = 124
            };

            var result = userController.CreateUser(user);

            AssertApiResponse(result, HttpStatusCode.OK, Constants.SuccessUserCreationMessage);
        }

        [Fact]
        public void ShouldCreateSuperUser()
        {
            var userController = new UsersController();
            var user = new UserDTO
            {
                Name = "Test2",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Premium",
                Money = 124
            };

            var result = userController.CreateUser(user);

            AssertApiResponse(result, HttpStatusCode.OK, Constants.SuccessUserCreationMessage);
        }

        [Fact]
        public void ShouldNotCreateDuplicatedUser()
        {
            var userController = new UsersController();
            var user = new UserDTO
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Garay y Otra Calle",
                Phone = "+534645213542",
                UserType = "SuperUser",
                Money = 112234
            };

            var result = userController.CreateUser(user);

            AssertApiResponse(result, HttpStatusCode.BadRequest, Constants.DuplicatedUserErrorMessage);
        }

        [Fact]
        public void ShouldNotCreateInvalidUserProperties()
        {
            var userController = new UsersController();
            var user = new UserDTO
            {
                Name = "",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            var result = userController.CreateUser(user);

            AssertApiResponse(result, HttpStatusCode.BadRequest, SchemaValidatorMinNameLength);
        }

        [Fact]
        public void ShouldNotCreateInvalidUserType()
        {
            var userController = new UsersController();
            var user = new UserDTO
            {
                Name = "TestName",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "InvalidType",
                Money = 124
            };

            var result = userController.CreateUser(user);

            AssertApiResponse(result, HttpStatusCode.InternalServerError, InvalidTypeArgException);
        }

        private static void AssertApiResponse(ApiResponse result, HttpStatusCode statusCode, string message)
        {
            Assert.Equal(statusCode, result.StatusCode);
            Assert.Equal(message, result.Message);
        }
    }
}
