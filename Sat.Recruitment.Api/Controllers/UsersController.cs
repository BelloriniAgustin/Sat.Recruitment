using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Entities;
using Sat.Recruitment.Helpers;
using Sat.Recruitment.Helpers.UserFactory;
using System;
using System.Collections.Generic;
using System.Net;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly List<User> _users = new List<User>();

        public UsersController()
        {
            _users = FileReader.ReadUsersFromFile();
        }

        [HttpPost]
        [Route("/users")]
        public ApiResponse CreateUser(User user)
        {
            try
            {
                var responseMessage = "";

                if (!Validator.IsValidUser(user, ref responseMessage))
                {
                    return new ApiResponse()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = string.IsNullOrEmpty(responseMessage) ? "Ivalid user" : responseMessage
                    };
                }

                if (Validator.IsDuplicatedUser(user, _users, ref responseMessage))
                {
                    return new ApiResponse()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = string.IsNullOrEmpty(responseMessage) ? "Duplicated user" : responseMessage
                    };
                }

                User newUser = null;

                switch (user.UserType)
                {
                    case "Normal":
                        newUser = new NormalFactory().CreateUser(user.Name, user.Email, user.Phone, user.Address, user.UserType, user.Money);
                        break;
                    case "SuperUser":
                        newUser = new SuperUserFactory().CreateUser(user.Name, user.Email, user.Phone, user.Address, user.UserType, user.Money);
                        break;
                    case "Premium":
                        newUser = new PremiumFactory().CreateUser(user.Name, user.Email, user.Phone, user.Address, user.UserType, user.Money);
                        break;
                    default:
                        throw new ArgumentException("Invalid type", user.UserType);
                }

                newUser.ApplyGift();

                return new ApiResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "User successfully created"
                };
            }
            catch (Exception exception)
            {
                return new ApiResponse()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = exception.Message
                };
            }
        }
    }
}
