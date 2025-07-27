using polimark.core.ConnectionSwagger.models;
using polimark.core.PoliMark.models;
using polimark.infrastructure.Data;
using Microsoft.Extensions.Configuration;
using polimark.infrastructure.Data.models;

namespace polimark.core.ConnectionSwagger
{
    public class PoliMark : IPoliMark
    {
        private readonly IconnectionSql _db;
        private readonly IConfiguration _config;
        public PoliMark(IconnectionSql postgresql, IConfiguration configuration)
        {
            _db = postgresql;
            _config = configuration;
        }

        public async Task<ModelDataProduct> GetProduct(TokenModel data)
        {
            ModelDataProduct product = new ModelDataProduct();
            return product;
        }
        public async Task<ModelDataSupplier> GetSupplier(TokenModel data)
        {
            ModelDataSupplier supplier = new ModelDataSupplier();
            return supplier;
        }

        public async Task<ModelDataClient> GetClient(TokenModel data)
        {
            ModelDataClient client = new ModelDataClient();
            return client;
        }

    }
}
