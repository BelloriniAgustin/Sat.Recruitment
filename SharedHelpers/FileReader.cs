using Sat.Recruitment.Entities;
using Sat.Recruitment.Helpers.UserFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Helpers
{
    public static class FileReader
    {
        public static List<UserDTO> ReadUsersFromFile()
        {
            var users = new List<UserDTO>();

            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            var fileStream = new FileStream(path, FileMode.Open);

            var reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLine().Split(',');

                var userDTO = new UserDTO()
                {
                    Name = line[0].ToString(),
                    Email = line[1].ToString(),
                    Phone = line[2].ToString(),
                    Address = line[3].ToString(),
                    UserType = line[4].ToString(),
                    Money = decimal.Parse(line[5].ToString())
                };

                switch (userDTO.UserType)
                {
                    case "Normal":
                        users.Add(new NormalFactory().CreateUser(userDTO));
                        break;
                    case "SuperUser":
                        users.Add(new SuperUserFactory().CreateUser(userDTO));
                        break;
                    case "Premium":
                        users.Add(new PremiumFactory().CreateUser(userDTO));
                        break;
                    default:
                        throw new ArgumentException("Invalid type", userDTO.UserType);
                }
            }

            reader.Close();

            return users;
        }
    }
}
