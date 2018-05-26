using System;
using System.Collections.Generic;

namespace VCI.DTO.Candidate
{
    public class CandidateDTO : UserDTO
    {

        public string Biography { get; set; }
        public List<ProfessionalTitleDTO> ProfessionalTitles { get; set; }
        public string PoliticParty { get; set; }
        public List<ProposalDTO> Porposals { get; set; }
        public Uri ProfileFoto { get; set; }

        public CandidateDTO() { }

        public CandidateDTO(Request.Candidate candidate) : base(candidate.Names, candidate.LastNames, candidate.Phone, candidate.Email, candidate.BirthDate, candidate.Identification)
        {
            Biography = candidate.Biography;
            PoliticParty = candidate.PoliticParty;
        }
    }
}