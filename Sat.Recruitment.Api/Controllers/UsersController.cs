using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Entities;
using Sat.Recruitment.Helpers;
using Sat.Recruitment.Helpers.UserFactories;
using System;
using System.Collections.Generic;
using System.Net;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IList<UserDTO> _users = new List<UserDTO>();

        public UsersController()
        {
            _users = UsersFileHelper.ReadUsersFromFile();
        }

        [HttpPost]
        [Route("~/users")]
        public ApiResponse CreateUser([FromBody] UserDTO user)
        {
            try
            {
                var responseMessage = string.Empty;

                if (!Validator.IsValidUser(user, _users, ref responseMessage))
                {
                    return new ApiResponse()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = string.IsNullOrEmpty(responseMessage) ? Constants.InvalidUserDefaultMessage : responseMessage
                    };
                }

                var newUser = UserFactory.CreateUser(user);

                newUser.ApplyGift();

                return new ApiResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = Constants.SuccessUserCreationMessage
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
