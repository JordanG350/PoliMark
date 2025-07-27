using polimark.core.ConnectionSwagger.models;
using polimark.core.PoliMark.models;
using polimark.infrastructure.Data;
using Microsoft.Extensions.Configuration;
using polimark.infrastructure.Data.models;
using ZstdSharp.Unsafe;

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

    }
}
