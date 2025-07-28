using Microsoft.AspNetCore.Mvc;
using PoliMark.Api.models;
using PoliMark.infraestructure.Service;

namespace polimark.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _Login;

        public AuthController(ILoginService loginService)
        {
            _Login = loginService;
        }

        //Metodo de autenticacion
        [HttpPost]
        public async Task<ActionResult> login(RequestLogin data)
        {
            try
            {
                var User = await _Login.ValidateUser(data.username, data.password);
                if (User.token == null)
                {
                    return Ok("No existe el usuario.");
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