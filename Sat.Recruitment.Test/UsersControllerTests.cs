using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Entities;
using System.Net;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerTests
    {
        [Fact]
        public void ShouldCreateNormalUser()
        {
            var userController = new UsersController();
            var user = new Normal
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            var result = userController.CreateUser(user);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("User successfully created", result.Message);
        }

        [Fact]
        public void ShouldCreatePremiumUser()
        {
            var userController = new UsersController();
            var user = new Premium
            {
                Name = "Test",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Premium",
                Money = 124
            };

            var result = userController.CreateUser(user);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("User successfully created", result.Message);
        }

        [Fact]
        public void ShouldCreateSuperUser()
        {
            var userController = new UsersController();
            var user = new SuperUser
            {
                Name = "Test2",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Premium",
                Money = 124
            };

            var result = userController.CreateUser(user);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("User successfully created", result.Message);
        }

        [Fact]
        public void ShouldNotCreateDuplicatedUser()
        {
            var userController = new UsersController();
            var user = new SuperUser
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Garay y Otra Calle",
                Phone = "+534645213542",
                UserType = "SuperUser",
                Money = 112234
            };

            var result = userController.CreateUser(user);


            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("User is duplicated", result.Message);
        }

        [Fact]
        public void ShouldNotCreateInvalidUser()
        {
            var userController = new UsersController();
            var user = new Normal
            {
                Name = "",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            var result = userController.CreateUser(user);


            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("String '' is less than minimum length of 1. Path 'Name'.", result.Message);
        }
    }
}
