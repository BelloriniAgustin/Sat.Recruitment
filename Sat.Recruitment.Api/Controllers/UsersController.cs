using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sat.Recruitment.Entities;
using Sat.Recruitment.Helpers;
using Sat.Recruitment.Helpers.UserFactories;
using Serilog;
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
                Log.Information("Create user method triggered by: {0}", JsonConvert.SerializeObject(user));

                var responseMessage = string.Empty;

                if (!Validator.IsValidUser(user, _users, ref responseMessage))
                {
                    return new ApiResponse()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = string.IsNullOrEmpty(responseMessage) ? Constants.InvalidUserDefaultMessage : responseMessage
                    };
                }

                Log.Information("User is valid");

                var newUser = UserFactory.CreateUser(user);

                newUser.ApplyGift();

                Log.Information("User created: {0}", JsonConvert.SerializeObject(newUser));

                return new ApiResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = string.Format(Constants.SuccessUserCreationMessage, newUser.Money)
                };
            }
            catch (Exception exception)
            {
                Log.Error("Exception found: {0}", exception.Message);

                return new ApiResponse()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = exception.Message
                };
            }
        }
    }
}
