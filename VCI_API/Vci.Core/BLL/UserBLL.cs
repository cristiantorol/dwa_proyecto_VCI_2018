using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using VCI.DTO;

namespace VCI.BLL
{
    public class UserBLL : BaseBLL<UserDTO>
    {
        private readonly static Lazy<UserBLL> _instance = new Lazy<UserBLL>(() => new UserBLL());

        public static UserBLL Instance { get { return _instance.Value; } }

        private UserBLL() : base("User") { }

        public override UserDTO Create(UserDTO element)
        {
            throw new NotImplementedException();
        }

        public override UserDTO Update(UserDTO element)
        {
            throw new NotImplementedException();
        }

    }
}