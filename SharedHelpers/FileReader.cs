using Sat.Recruitment.Entities;
using Sat.Recruitment.Helpers.UserFactories;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Helpers
{
    public static class FileReader
    {
        public static List<UserDTO> ReadUsersFromFile()
        {
            var users = new List<UserDTO>();

            var path = Directory.GetCurrentDirectory() + Constants.UsersFilePath;

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

                users.Add(UserFactory.CreateUser(userDTO));
            }

            reader.Close();

            return users;
        }
    }
}
