using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using VCI.BLL;
using VCI.DTO.Candidate;
using VCI.DTO.Request;
using VCI.Utils;

namespace VCI_API.Controllers.Candidate
{
    public class CandidateController : ApiController
    {
        public async Task<Response<List<CandidateDTO>>> Get()
        {
            Response<List<CandidateDTO>> Result = new Response<List<CandidateDTO>>();
            try
            {
                Result.Result = await CandidateBLL.Instance.GetAll();
                Result.Success = true;
            }catch(Exception e)
            {

            }
            return Result;
        }

        public Response<CandidateDTO> Post([FromBody] VCI.DTO.Request.Candidate Candidate)
        {
            Response<CandidateDTO> Result = new Response<CandidateDTO>();
            CandidateDTO CandidateCreated;
            BlobStorageBLL BlobStorage = new BlobStorageBLL();
            Uri profileFoto;
            try
            {
                CandidateCreated = new CandidateDTO(Candidate);
                profileFoto = BlobStorage.SaveCandidateFoto(Candidate);
                if(profileFoto == null)
                {
                    Result.Error = Error.Random;
                    return Result;
                }
                CandidateCreated.ProfileFoto = profileFoto;
                CandidateCreated = CandidateBLL.Instance.Create(CandidateCreated);

                Result.Result = CandidateCreated;
                Result.Success = true;
            }catch(Exception e)
            {

            }
            return Result;
        }

    }
}