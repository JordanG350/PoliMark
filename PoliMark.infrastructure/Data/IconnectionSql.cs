using polimark.infrastructure.Data.models;
using PoliMark.infraestructure.Data.models;

namespace polimark.infrastructure.Data
{
    public interface IconnectionSql
    {
        Task<TokenModel> getUsers(string user, string password);
        Task<List<productsModel>?> getProducts();
        Task<List<customersModel>?> getCustomers();
    }
}
