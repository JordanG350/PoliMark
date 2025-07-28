using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using polimark.core.ConnectionSwagger;
using polimark.core.ConnectionSwagger.models;
using polimark.core.PoliMark.models;
using PoliMark.Api.models;

namespace polimark.Controllers
{

    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class PoliMarketController : ControllerBase
    {
        private readonly IPoliMark _pm;

        public PoliMarketController(IPoliMark poliMark)
        {
            _pm = poliMark;
        }

        [HttpGet]
        [Authorize]
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
        public async Task<ActionResult> customers()
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

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RegisterProducts(RegisterProductsModel registerProduct)
        {
            try
            {
                var product = new ModelDataProduct
                {
                    tax_id = registerProduct.tax_id,
                    name = registerProduct.name,
                    quantity = registerProduct.quantity
                };
                var supplier = new ModelDataSupplier
                {
                    tax_id = registerProduct.tax_id,
                    company = registerProduct.company,
                    phone = registerProduct.phone,
                    email = registerProduct.email
                };
                await _pm.RegisterProduct(product, supplier);
                return Ok("Registro exitoso");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo fallo!" + ex.ToString());
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RegisterCustomer(RegisterClientModel registerClient)
        {
            try
            {
                var customer =  new ModelDataCustomer
                {
                    dni = registerClient.dni,
                    first_name = registerClient.first_name,
                    last_name = registerClient.last_name,
                    phone = registerClient.phone,
                    email = registerClient.email,
                    address = registerClient.address
                };
                await _pm.RegisterCustomer(customer);
                return Ok("Registro exitoso");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo fallo!" + ex.ToString());
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> MakeSale(RequestSale data)
        {
            try
            {
                var listProducts = data.listProducts.Select(modelo => new ModelDataProduct
                {
                    tax_id = modelo.tax_id,
                    name = modelo.name,
                    quantity = modelo.quantity
                }).ToList();
                var result = await _pm.MakeSale(data.client_id, data.seller_id, listProducts);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Algo fallo!" + ex.ToString());
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> BuyProducts(RequestBuyProducts data)
        {
            try
            {
                var listProducts = data.listProducts.Select(modelo => new ModelDataProduct
                {
                    tax_id = modelo.tax_id,
                    name = modelo.name,
                    quantity = modelo.quantity
                }).ToList();
                var result = await _pm.BuyProducts(listProducts);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Algo fallo!" + ex.ToString());
            }
        }
    }
}