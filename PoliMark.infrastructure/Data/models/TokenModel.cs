using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polimark.infrastructure.Data.models
{
    public class TokenModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string user { get; set; }
        public string password { get; set; }
    }
}
