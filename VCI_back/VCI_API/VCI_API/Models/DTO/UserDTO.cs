using System;

namespace VCI_API.Models.DTO
{
    public class UserDTO : BaseDTO
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public RoleDTO role { get; set; }
        public string username { get; set; }

        [NonSerialized]
        public string password;
    }
}