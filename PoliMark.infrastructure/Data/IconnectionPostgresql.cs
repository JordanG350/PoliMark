using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maasapp.infrastructure.Data
{
    public interface IconnectionPostgresql
    {
        Task<modelData> getUsers(string typeDocument, string documentNumber);
    }
}
