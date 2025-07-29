using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMark.infraestructure.Data.models
{
    public class ResponseModelUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string user { get; set; }
        public string token { get; set; }
    }
}
