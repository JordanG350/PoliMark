using polimark.infrastructure.Data.models;

namespace polimark.infrastructure.Data
{
    public interface IconnectionSql
    {
        Task<TokenModel> getUsers(string user, string password);
    }
}
