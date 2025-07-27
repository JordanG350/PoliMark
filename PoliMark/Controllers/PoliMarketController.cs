using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using polimark.core.ConnectionSwagger;
using polimark.infrastructure.Data;
using polimark.infrastructure.Data.models;

namespace polimark.Controllers
{

    [ApiController]
    public class PoliMarketController : ControllerBase
    {
        private readonly IPoliMark _pm;

        public PoliMarketController(IPoliMark poliMark)
        {
            _pm = poliMark;
        }

        [HttpGet]
        [Authorize]
        [Route("products")]
        public async Task<ActionResult> products()
        {
            try
            {
                return Ok(await _pm.getProducts());
            }
            catch (Exception ex)
            {
                return BadRequest("Algo fallo!" + ex.ToString());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("clients")]
        public async Task<ActionResult> clients()
        {
            try
            {
                return Ok(await _pm.getCustomers());
            }
            catch (Exception ex)
            {
                return BadRequest("Algo fallo!" + ex.ToString());
            }
        }

        //[HttpGet]
        //[Authorize]
        //[Route("sales")]
        //public async Task<ActionResult> sales(TokenModel data)
        //{
        //    try
        //    {
        //        return Ok(_pm.GetSupplier(data));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Algo fallo!" + ex.ToString());
        //    }
        //}
    }
}