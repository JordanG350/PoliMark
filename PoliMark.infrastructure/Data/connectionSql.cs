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
        public async Task<List<suppliersModel>?> getSuppliers()
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.QueryAsync<suppliersModel>(
                   $"SELECT * FROM polimarket.supplier");
                if (result.AsList().Count == 0)
                    return null;
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }
        public async Task InsertSupplier(int tax_id, string company, string phone, string email)
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.ExecuteAsync(
                   $"INSERT INTO supplier " +
                   $"(`tax_id`, `company`, `phone`, `email`) " +
                   $"VALUES ({tax_id}, '{company}', '{phone}', '{email}')");
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }
        public async Task InsertProduct(int tax_id, string name, int quantity, int id_supplier)
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.ExecuteAsync(
                   $"INSERT INTO product " +
                   $"(`tax_id`, `name`, `quantity`, `id_supplier`) " +
                   $"VALUES ({tax_id}, '{name}', '{quantity}', '{id_supplier}')");
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }

        public async Task InsertCustomers(string dni, string first_name, string last_name, string phone, string email, string address)
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.ExecuteAsync(
                   $"INSERT INTO customer " +
                   $"(`dni`, `first_name`, `last_name`, `phone`, `email`, `address`) " +
                   $"VALUES ({dni}, '{first_name}', '{last_name}', '{phone}', '{email}', '{address}') ");               
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }

        public async Task<bool> ExistUser(int userId)
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.QueryAsync<TokenModel>(
                   $"SELECT * FROM seller where id = '{userId}' ");
                if (result.AsList().Count == 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }

        public async Task UpdateQuantityProduct(int productId, int newQuantity)
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.ExecuteAsync(
                   $"UPDATE product SET `quantity` = {newQuantity} WHERE `tax_id` = {productId}");
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }

        public async Task InsertSale(int clientId, int sellerId, string saleId)
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.ExecuteAsync(
                   $"INSERT INTO sale " +
                   $"(`customer_id`, `sale_id`, `seller_id`) " +
                   $"VALUES ({clientId}, '{saleId}', '{sellerId}') ");
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }

        public async Task InsertDelivery(string saleId, int clientId)
        {
            try
            {
                using var connection = new MySqlConnection(_config["ConnectionString"]);
                await connection.OpenAsync();
                var result = await connection.ExecuteAsync(
                   $"INSERT INTO delivery " +
                   $"(`sale_id`, `customer_id`) " +
                   $"VALUES ('{saleId}', '{clientId}') ");
            }
            catch (Exception ex)
            {
                throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }
        }

    }
}
