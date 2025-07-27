using polimark.core.ConnectionSwagger.models;
using polimark.core.PoliMark.models;
using polimark.infrastructure.Data.models;

namespace polimark.core.ConnectionSwagger
{
    public interface IPoliMark
    {
        Task<ModelDataProduct> GetProduct(TokenModel data);
        Task<ModelDataSupplier> GetSupplier(TokenModel data);
        Task<ModelDataClient> GetClient(TokenModel data);
    }
}
