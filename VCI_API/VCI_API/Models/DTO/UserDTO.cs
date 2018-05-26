using System;

namespace VCI_API.Models.DTO
{
    public class UserDTO : BaseDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public RoleDTO Role { get; set; }

        [NonSerialized]
        public string Password;
    }
}