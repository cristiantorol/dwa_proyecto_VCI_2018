using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using VCI_API.Models.DTO;

namespace VCI_API.Models.DAL
{
    public class UserDAL : BaseDAL<UserDTO>
    {
        private readonly static Lazy<UserDAL> _instance = new Lazy<UserDAL>(() => new UserDAL());

        public static UserDAL instance { get { return _instance.Value; } }

        private UserDAL() : base("User") { }


        public async Task<UserDTO> Login(string username, string password)
        {
            FilterDefinitionBuilder<UserDTO> builder = Builders<UserDTO>.Filter;
            FilterDefinition<UserDTO> filter = builder.Eq(x => x.username, username) & builder.Eq(x => x.password, password);
            UserDTO user  = await GetByFilter(filter);
            return user;
        }

        public override void SetBasicProjection()
        {
            ProjectionDefinition<UserDTO> projection = Builders<UserDTO>.Projection
                .Exclude(x => x.password);
            this.projection = projection;
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