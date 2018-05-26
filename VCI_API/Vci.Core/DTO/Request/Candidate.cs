namespace VCI.DTO.Request
{
    public class Candidate : UserDTO
    {
        public string Biography { get; set; }
        public string PoliticParty { get; set; }
        public string ProfileFotoBase64 { get; set; }
        public string ProfileFotoFormat { get; set; }
    }
}
