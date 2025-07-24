using maasapp.core.ConnectionSwagger.models;
using maasapp.core.PoliMark.models;
using maasapp.infrastructure.Data.Models;

namespace maasapp.core.ConnectionSwagger
{
    public interface IPoliMark
    {
        Task<ModelDataProduct> GetProduct(CreationModel data);
        Task<ModelDataSupplier> GetSupplier(CreationModel data);
        Task<ModelDataClient> GetClient(CreationModel data);
    }
}
