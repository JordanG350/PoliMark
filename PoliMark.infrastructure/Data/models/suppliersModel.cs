using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMark.infraestructure.Data.models
{
    public class suppliersModel
    {
        public int id { get; set; }
        public int tax_id { get; set; }
        public string company { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
