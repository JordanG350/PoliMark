using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polimark.core.PoliMark.models
{
    public class ModelDataCustomer
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    }
}
