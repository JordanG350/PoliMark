using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Npgsql;
using polimark.infrastructure.Data.models;
using PoliMark.infraestructure.Data.models;
using System.Data.SqlClient;

namespace polimark.infrastructure.Data
{
    public class connectionSql : IconnectionSql
    {
        private readonly IConfiguration _config;
        public connectionSql(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<TokenModel?> getUsers(string user, string password)
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.QueryAsync<TokenModel>(
                   $"SELECT * FROM seller where user = '{user}' and password = '{password}'");
                if (result.AsList().Count == 0)
                    return null;
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }

        public async Task<List<productsModel>?> getProducts()
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.QueryAsync<productsModel>(
                   $"SELECT * FROM polimarket.product");
                if (result.AsList().Count == 0)
                    return null;
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }

        public async Task<List<customersModel>?> getCustomers()
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.QueryAsync<customersModel>(
                   $"SELECT * FROM polimarket.customer");
                if (result.AsList().Count == 0)
                    return null;
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }
    }
}
