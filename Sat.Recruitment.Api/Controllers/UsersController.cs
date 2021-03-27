using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Entities;
using Sat.Recruitment.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

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
        public async Task<ApiResponse> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            try
            {
                var errors = "";

                if (!Validator.IsValidUser(name, email, address, phone, ref errors))
                {
                    return new ApiResponse()
                    {
                        IsSuccess = false,
                        Errors = string.IsNullOrEmpty(errors) ? "Ivalid user" : errors
                    };
                }

                if (Validator.IsDuplicatedUser(name, Utils.NormalizeEmail(email), address, phone, _users, ref errors))
                {
                    return new ApiResponse()
                    {
                        IsSuccess = false,
                        Errors = String.IsNullOrEmpty(errors) ? "Duplicated user" : errors
                    };
                }

                var newUser = new User
                {
                    Name = name,
                    Email = email,
                    Address = address,
                    Phone = phone,
                    UserType = userType,
                    Money = decimal.Parse(money)
                };

                if (newUser.UserType == "Normal")
                {
                    if (decimal.Parse(money) > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        //If new user is normal and has more than USD100
                        var gif = decimal.Parse(money) * percentage;
                        newUser.Money = newUser.Money + gif;
                    }
                    if (decimal.Parse(money) < 100)
                    {
                        if (decimal.Parse(money) > 10)
                        {
                            var percentage = Convert.ToDecimal(0.8);
                            var gif = decimal.Parse(money) * percentage;
                            newUser.Money = newUser.Money + gif;
                        }
                    }
                }
                if (newUser.UserType == "SuperUser")
                {
                    if (decimal.Parse(money) > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = decimal.Parse(money) * percentage;
                        newUser.Money = newUser.Money + gif;
                    }
                }
                if (newUser.UserType == "Premium")
                {
                    if (decimal.Parse(money) > 100)
                    {
                        var gif = decimal.Parse(money) * 2;
                        newUser.Money = newUser.Money + gif;
                    }
                }

                return new ApiResponse()
                {
                    IsSuccess = true,
                    Errors = "User successfully created" //TODO
                };
            }
            catch
            {
                Debug.WriteLine("The user is duplicated"); //TODO

                return new ApiResponse()
                {
                    IsSuccess = false,
                    Errors = "The user is duplicated" //TODO
                };
            }
        }
    }
}
