using maasapp.core.ConnectionSwagger;
using maasapp.infrastructure.Data;
using maasapp.infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maasapp.Controllers
{

    [ApiController]
    // ruta de donde esta el metodo que se llama, en este caso api
    // [Route("[controller]")]
    public class PoliMarketController : ControllerBase
    {
        // se llama la interface en _db 
        private readonly IconnectionPostgresql _db;
        private readonly IPoliMark _pm;

        // constructor igualado a la variable traida de la interface
        public PoliMarketController(IconnectionPostgresql connectionpostgesql, IPoliMark poliMark)
        {
            _db = connectionpostgesql;
            _pm = poliMark;
        }
        //ActionResult Retorna un evento
        //Metodo de autenticacion
        [HttpGet]
        [Authorize]
        [Route("products")]
        public async Task<ActionResult> products(CreationModel data)
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
        public async Task<ActionResult> clients(CreationModel data)
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
        public async Task<ActionResult> sales(CreationModel data)
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