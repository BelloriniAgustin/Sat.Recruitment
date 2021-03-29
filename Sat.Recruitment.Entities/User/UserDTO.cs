using System;
using System.Linq;

namespace Sat.Recruitment.Entities
{
    public class UserDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string UserType { get; set; }

        public decimal Money { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserDTO userDTO && userDTO.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Email, Address, Phone, UserType);
        }
    }
}