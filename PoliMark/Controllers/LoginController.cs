using Microsoft.AspNetCore.Mvc;
using PoliMark.Api.models;
using PoliMark.infraestructure.Service;

namespace polimark.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _Login;

        public LoginController(ILoginService loginService)
        {
            _Login = loginService;
        }

        //Metodo de autenticacion
        [HttpPost]
        [Route("GetToken")]
        public async Task<ActionResult> GetToken(RequestLogin data)
        {
            try
            {
                string User = await _Login.ValidateUser(data.user, data.password);
                if (User != "No existe el usuario")
                {
                    return Ok(new { Token = User });
                }
                return Ok(User);
            }
            catch (Exception)
            {
                return BadRequest("Algo fallo!");
            }
        }
    }
}