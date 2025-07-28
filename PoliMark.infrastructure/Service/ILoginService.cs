using PoliMark.infraestructure.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMark.infraestructure.Service
{
    public interface ILoginService
    {
        Task<ResponseModelUser> ValidateUser(string user, string password);
    }
}
