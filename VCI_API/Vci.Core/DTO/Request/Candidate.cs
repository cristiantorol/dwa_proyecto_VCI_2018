using System.Collections.Generic;
using Vci.Core.DTO.Request;
using VCI.DTO.Candidate;

namespace VCI.DTO.Request
{
    public class Candidate : UserDTO
    {
        public string Biography { get; set; }
        public string PoliticParty { get; set; }
        public FileBase64 ProfileFoto { get; set; }
        public List<ProfessionalTitle> ProfessinalTitles { get; set; }
        public List<ProposalDTO> Proposals { get; set; }
    }
}
