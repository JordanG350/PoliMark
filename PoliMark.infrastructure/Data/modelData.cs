using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polimark.infrastructure.Data
{
    public class modelData
    {
        // mapear datos de la base de datos para poder usarlos.
        public int id { get; set; }
        public string name { get; set;}
        public string second_name { get; set;}
        public string document_type { get; set;}
        public int identity { get; set; }
        public string serial_number { get; set; }
    }
}
