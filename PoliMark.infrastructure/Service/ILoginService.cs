using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMark.infraestructure.Service
{
    public interface ILoginService
    {
        Task<string> ValidateUser(string user, string password);
    }
}
