using System;

namespace VCI.DTO
{
    public class UserDTO : BaseDTO
    {
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Identification { get; set; }

        public UserDTO() { }

        public UserDTO(string names, string lastNames, string phone, string email, DateTime birthDate, string identification)
        {
            Names = names;
            LastNames = lastNames;
            Phone = phone;
            Email = email;
            BirthDate = birthDate;
            Identification = identification;
        }
    }
}