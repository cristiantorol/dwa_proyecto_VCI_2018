using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using VCI_API.Models.DTO;

namespace VCI_API.Models.BLL
{
    public class UserBLL : BaseBLL<UserDTO>
    {
        private readonly static Lazy<UserBLL> _instance = new Lazy<UserBLL>(() => new UserBLL());

        public static UserBLL Instance { get { return _instance.Value; } }

        private UserBLL() : base("User") { }


        public async Task<UserDTO> Login(string Username, string Password)
        {
            FilterDefinitionBuilder<UserDTO> builder = Builders<UserDTO>.Filter;
            FilterDefinition<UserDTO> filter = builder.Eq(x => x.Email, Username) & builder.Eq(x => x.Password, Password);
            UserDTO user  = await GetByFilter(filter);
            return user;
        }

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