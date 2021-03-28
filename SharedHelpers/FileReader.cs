using Sat.Recruitment.Entities;
using Sat.Recruitment.Helpers.UserFactory;
using System;
using System.Collections.Generic;
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
                var name = line.Split(',')[0].ToString();
                var email = line.Split(',')[1].ToString();
                var phone = line.Split(',')[2].ToString();
                var address = line.Split(',')[3].ToString();
                var userType = line.Split(',')[4].ToString();
                var money = decimal.Parse(line.Split(',')[5].ToString());

                switch (userType)
                {
                    case "Normal":
                        users.Add(new NormalFactory().CreateUser(name, email, phone, address, userType, money));
                        break;
                    case "SuperUser":
                        users.Add(new SuperUserFactory().CreateUser(name, email, phone, address, userType, money));
                        break;
                    case "Premium":
                        users.Add(new PremiumFactory().CreateUser(name, email, phone, address, userType, money));
                        break;
                    default:
                        throw new ArgumentException("Invalid type", userType);
                }
            }

            reader.Close();

            return users;
        }
    }
}
