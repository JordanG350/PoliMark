using polimark.core.ConnectionSwagger.models;
using polimark.core.PoliMark.models;
using polimark.infrastructure.Data.models;
using PoliMark.Core.PoliMark.models;

namespace polimark.core.ConnectionSwagger
{
    public interface IPoliMark
    {
        Task<List<ModelDataProduct>> getProducts();
        Task<List<ModelDataCustomer>> getCustomers();
        Task<List<ModelResponseSale>> MakeSale(int clientId, int sellerId, List<ModelDataProduct> products);
        Task RegisterProduct(ModelDataProduct dataProduct, ModelDataSupplier dataSupplier);
        Task RegisterCustomer(ModelDataCustomer dataCustomer);
        Task<List<ModelResponseBuyProducts>> BuyProducts(List<ModelDataProduct> dataProducts);
    }
}
