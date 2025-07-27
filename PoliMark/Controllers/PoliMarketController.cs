using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using polimark.core.ConnectionSwagger;
using polimark.infrastructure.Data;
using polimark.infrastructure.Data.models;

namespace polimark.Controllers
{

    [ApiController]
    // ruta de donde esta el metodo que se llama, en este caso api
    // [Route("[controller]")]
    public class PoliMarketController : ControllerBase
    {
        // se llama la interface en _db 
        private readonly IconnectionSql _db;
        private readonly IPoliMark _pm;

        // constructor igualado a la variable traida de la interface
        public PoliMarketController(IconnectionSql connectionpostgesql, IPoliMark poliMark)
        {
            _db = connectionpostgesql;
            _pm = poliMark;
        }
        //ActionResult Retorna un evento
        //Metodo de autenticacion
        [HttpGet]
        [Authorize]
        [Route("products")]
        public async Task<ActionResult> products(TokenModel data)
        {
            try
            {
                return Ok(_pm.GetProduct(data));
            }
            catch (Exception ex)
            {
                return BadRequest("Algo fallo!" + ex.ToString());
            }
        }
        //ActionResult Retorna un evento
        //Metodo de autenticacion
        [HttpGet]
        [Authorize]
        [Route("clients")]
        public async Task<ActionResult> clients(TokenModel data)
        {
            try
            {
                return Ok(_pm.GetClient(data));
            }
            catch (Exception ex)
            {
                return BadRequest("Algo fallo!" + ex.ToString());
            }
        }
        //ActionResult Retorna un evento
        //Metodo de autenticacion
        [HttpGet]
        [Authorize]
        [Route("sales")]
        public async Task<ActionResult> sales(TokenModel data)
        {
            try
            {
                return Ok(_pm.GetSupplier(data));
            }
            catch (Exception ex)
            {
                return BadRequest("Algo fallo!" + ex.ToString());
            }
        }
    }
}