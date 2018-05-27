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

        public Response<CandidateDTO> Post([FromBody] VCI.DTO.Request.Candidate candidate)
        {
            Response<CandidateDTO> Result = new Response<CandidateDTO>();
            CandidateDTO CandidateCreated;
            BlobStorageBLL BlobStorage = new BlobStorageBLL();
            Uri profileFoto;
            ProfessionalTitleDTO ProfessionalTitle;
            try
            {
                CandidateCreated = new CandidateDTO(candidate);

                //Aqui se guarda la foto de perfil y los archivos de los titulos profesionales
                candidate.ProfileFoto.Name = string.Format("{0}_profilefoto", candidate.Identification);
                profileFoto = BlobStorage.SaveFile(candidate.Identification, candidate.ProfileFoto);
                if(profileFoto == null)
                {
                    Result.Error = Error.Random;
                    return Result;
                }
                CandidateCreated.ProfileFoto = profileFoto;

                int cont = 0;
                if(candidate.ProfessinalTitles != null)
                {
                    foreach (var aux in candidate.ProfessinalTitles)
                    {
                        if (string.IsNullOrEmpty(aux.Base64) || string.IsNullOrEmpty(aux.Format))
                        {
                            Result.Error = Error.AllProfessionalTitlesRequiredFile;
                            return Result;
                        }
                        ProfessionalTitle = new ProfessionalTitleDTO();
                        ProfessionalTitle.Name = aux.Title;
                        aux.Name = string.Format("ProfessionalTitle_{0}", cont);
                        ProfessionalTitle.URL = BlobStorage.SaveFile(candidate.Identification, aux);
                        if (ProfessionalTitle.URL == null)
                        {
                            Result.Error = Error.InternalError;
                            return Result;
                        }
                        CandidateCreated.ProfessionalTitles.Add(ProfessionalTitle);
                        cont++;
                    }
                }
                
                //Se guarda el candidato en la base de datos
                CandidateCreated = CandidateBLL.Instance.Create(CandidateCreated);

                Result.Result = CandidateCreated;
                Result.Success = true;
            }catch
            {
                Result.Error = Error.InternalError;
            }
            return Result;
        }

    }
}