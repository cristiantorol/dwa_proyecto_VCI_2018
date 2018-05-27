using System;
using VCI.DTO.Candidate;

namespace VCI.BLL
{
    public class CandidateBLL : BaseBLL<CandidateDTO>
    {
        private readonly static Lazy<CandidateBLL> _instance = new Lazy<CandidateBLL>(() => new CandidateBLL());

        public static CandidateBLL Instance { get { return _instance.Value; } }

        private CandidateBLL() : base("Candidates") { }

        public override CandidateDTO Create(CandidateDTO element)
        {
            CandidateDTO Candidate = Insert(element);
            return Candidate;
        }

        public override CandidateDTO Update(CandidateDTO element)
        {
            throw new NotImplementedException();
        }
    }
}