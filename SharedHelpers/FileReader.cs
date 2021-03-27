using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Sat.Recruitment.Helpers
{
    public static class FileReader
    {
        public static List<User> ReadUsersFromFile()
        {
            var users = new List<User>();

            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            var fileStream = new FileStream(path, FileMode.Open);

            var reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                users.Add(user);
            }
            reader.Close();

            return users;
        }
    }
}
