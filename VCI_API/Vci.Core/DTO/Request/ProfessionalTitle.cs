using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCI.DTO.Request;

namespace Vci.Core.DTO.Request
{
    public class ProfessionalTitle : FileBase64
    {
        public string Title { get; set; }
    }
}
