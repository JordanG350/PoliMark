using Microsoft.Extensions.Configuration;
using polimark.core.ConnectionSwagger.models;
using polimark.core.PoliMark.models;
using polimark.infrastructure.Data;
using PoliMark.Core.PoliMark.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace polimark.core.ConnectionSwagger
{
    public class PoliMark : IPoliMark
    {
        private readonly IconnectionSql _db;
        private readonly IConfiguration _config;
        public PoliMark(IconnectionSql connectionSql, IConfiguration configuration)
        {
            _db = connectionSql;
            _config = configuration;
        }

        public async Task<List<ModelDataProduct>> getProducts()
        {
            var ListProducts = await _db.getProducts();
            return ListProducts.Select(modelo => new ModelDataProduct
            {
                tax_id = modelo.tax_id,
                name = modelo.name,
                quantity = modelo.quantity
            }).ToList();
        }

        public async Task<List<ModelDataCustomer>> getCustomers()
        {
            var ListCustomers = await _db.getCustomers();
            return ListCustomers.Select(modelo => new ModelDataCustomer
            {
                id = modelo.id,
                dni = modelo.dni,
                first_name = modelo.first_name,
                last_name = modelo.last_name,
                phone = modelo.phone,
                email = modelo.email,
                address = modelo.address
            }).ToList();
        }

        public async Task RegisterProduct(ModelDataProduct dataProduct, ModelDataSupplier dataSupplier)
        {
            await _db.InsertSupplier(dataSupplier.tax_id, dataSupplier.company, dataSupplier.phone, dataSupplier.email);
            var listSuppliers = await _db.getSuppliers();
            var newSupplier = listSuppliers.Where(s => s.tax_id == dataSupplier.tax_id).FirstOrDefault();
            await _db.InsertProduct(dataProduct.tax_id, dataProduct.name, dataProduct.quantity, newSupplier.id);
        }

        public async Task RegisterCustomer(ModelDataCustomer dataCustomer)
        {
            await _db.InsertCustomers(dataCustomer.dni, dataCustomer.first_name, dataCustomer.last_name,
            dataCustomer.phone, dataCustomer.email, dataCustomer.address);
        }

        public async Task<List<ModelResponseSale>> MakeSale(int clientId, int sellerId, List<ModelDataProduct> products)
        {
            List<ModelResponseSale> responseSale = new List<ModelResponseSale>();
            var listClients = await getCustomers();
            var listProducts = await getProducts();
            var existClient = listClients.Where(c => c.id == clientId).FirstOrDefault();
            var existSeller = await _db.ExistUser(sellerId);
            if (!existSeller)
            {
                var response = new ModelResponseSale
                {
                    message = "No existe el vendedor: " + sellerId,
                    sale_id = "0"
                };
                responseSale.Add(response);
                return responseSale;
            }
            if (existClient == null)
            {
                var response = new ModelResponseSale
                {
                    message = "No existe el cliente: " + clientId,
                    sale_id = "0"
                };
                responseSale.Add(response);
                return responseSale;
            }
            var sale = await ValidateProducts(listProducts, products);

            var existSale = sale.Where(p => p.sale_id != "0").FirstOrDefault();
            if (existSale != null)
            {
                await _db.InsertSale(clientId, sellerId, existSale.sale_id);
                await _db.InsertDelivery(existSale.sale_id, clientId);
            }
            return sale;
        }

        public async Task RegisterSale(ModelDataCustomer dataCustomer)
        {
            await _db.InsertCustomers(dataCustomer.dni, dataCustomer.first_name, dataCustomer.last_name,
            dataCustomer.phone, dataCustomer.email, dataCustomer.address);
        }

        public async Task<List<ModelResponseSale>> ValidateProducts(List<ModelDataProduct> listProducts, List<ModelDataProduct> productsSale)
        {
            List<ModelResponseSale> responseSales = new List<ModelResponseSale>();
            int numProducts = productsSale.Count();
            int countProducts = 0;

            foreach (var product in productsSale)
            {
                var existProduct = listProducts.Where(p => p.tax_id == product.tax_id).FirstOrDefault();
                if (existProduct == null)
                {
                    var response = new ModelResponseSale
                    {
                        message = "No existe el producto " + product.name,
                        sale_id = "0"
                    };
                    responseSales.Add(response);
                }
                else if (existProduct.quantity < product.quantity)
                {
                    var response = new ModelResponseSale
                    {
                        message = "No hay la cantidad de producto.",
                        sale_id = "0"
                    };
                    responseSales.Add(response);
                }
                else
                {
                    countProducts++;
                }
            }

            if (countProducts == numProducts)
            {
                foreach (var product in productsSale)
                {
                    var existProduct = listProducts.Where(p => p.tax_id == product.tax_id).FirstOrDefault();
                    int newQuantity = existProduct.quantity - product.quantity;
                    await _db.UpdateQuantityProduct(product.tax_id, newQuantity);
                }

                var responseSale = new ModelResponseSale
                {
                    message = "Venta registrada exitosamente",
                    sale_id = Guid.NewGuid().ToString()
                };
                responseSales.Add(responseSale);
            }

            return responseSales;
        }

        public async Task<List<ModelResponseBuyProducts>> BuyProducts(List<ModelDataProduct> dataProducts)
        {
            var responseProducts = new List<ModelResponseBuyProducts>();
            var listProducts = await getProducts();
            foreach (var product in dataProducts)
            {
                var existProduct = listProducts.Where(p => p.tax_id == product.tax_id).FirstOrDefault();
                if (existProduct == null)
                {
                    var responseProduct = new ModelResponseBuyProducts
                    {
                        name = product.name,
                        message = "No se encuentra registrado el producto."
                    };
                    responseProducts.Add(responseProduct);
                }
                else
                {
                    int newQuantity = existProduct.quantity - product.quantity;
                    await _db.UpdateQuantityProduct(product.tax_id, newQuantity);
                    var responseProduct = new ModelResponseBuyProducts
                    {
                        name = product.name,
                        message = "Solicitud enviada a proveedores."
                    };
                    responseProducts.Add(responseProduct);
                }
            }
            return responseProducts;
        }

    }
}
