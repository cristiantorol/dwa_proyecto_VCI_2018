using System;
using System.Threading.Tasks;
using System.Web.Http;
using VCI_API.Models.BLL;
using VCI_API.Models.DTO;
using VCI_API.Models.DTO.Request;
using VCI_API.Models.Utils;

namespace VCI_API.Controllers
{
    public class LoginController : ApiController
    {

        // POST api/<controller>
        public async Task<Response<UserDTO>> Post([FromBody]Login Login)
        {
            Response<UserDTO> Result = new Response<UserDTO>();
            UserDTO User;
            try
            {
                User = await UserBLL.Instance.Login(Login.Email, Login.Password);
                if(User == null)
                {

                }
                else
                {
                    Result.Result = User;
                    Result.Success = true;
                }
            }catch(Exception e)
            {
                Result.Error = Error.Random;
            }
            return Result;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}