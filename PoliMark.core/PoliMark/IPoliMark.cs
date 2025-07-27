using polimark.core.ConnectionSwagger.models;
using polimark.core.PoliMark.models;
using polimark.infrastructure.Data.models;

namespace polimark.core.ConnectionSwagger
{
    public interface IPoliMark
    {
        Task<List<ModelDataProduct>> getProducts();
        Task<List<ModelDataCustomer>> getCustomers();
    }
}
