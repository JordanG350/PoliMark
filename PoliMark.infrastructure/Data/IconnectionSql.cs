using polimark.infrastructure.Data.models;
using PoliMark.infraestructure.Data.models;

namespace polimark.infrastructure.Data
{
    public interface IconnectionSql
    {
        Task<TokenModel> getUsers(string user, string password);
        Task<List<productsModel>?> getProducts();
        Task<List<customersModel>?> getCustomers();
        Task<List<suppliersModel>?> getSuppliers();
        Task InsertSupplier(int tax_id, string company, string phone, string email);
        Task InsertProduct(int tax_id, string name, int quantity, int id_supplier);
        Task InsertCustomers(string dni, string first_name, string last_name, string phone, string email, string address);
        Task<bool> ExistUser(int userId);
        Task UpdateQuantityProduct(int productId, int newQuantity);
        Task InsertSale(int clientId, int sellerId, string saleId);
        Task InsertDelivery(string saleId, int clientId);
    }
}
