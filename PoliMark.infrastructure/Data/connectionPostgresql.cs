using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maasapp.infrastructure.Data
{
    public class connectionPostgresql : IconnectionPostgresql
    {
        private readonly IConfiguration _config;
        public connectionPostgresql(IConfiguration configuration) 
        { 
            _config = configuration;
        }
        // Crear objeto de conexion.
        NpgsqlConnection connection = new NpgsqlConnection();

        // retornar un objeto model data, async para realziar peticiones.
        //{
        //"document_type": "cc",
        //"identity": 1222876543,
        //"serial_number": "1010000008551426"
        //}
        public async Task<modelData> getUsers(string typeDocument, string documentNumber)
        {
            try
            {
                // Objeto de modelData
                modelData modelData = new modelData();

                string query = "SELECT * FROM users WHERE document_type = "+"'"+ typeDocument+"'" + " AND identity = " + "'"+ documentNumber+"';";
                //Le pasamos variable al objeto de conexion, y abrimos dicha conexion
                connection.ConnectionString = _config["ConnectionString"];
                connection.Open();
                // command realiza la funcion de correr la query en los parametros establecidos en conneciton.
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                // Mapea command y lo guardamos en data.
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(command);

                // clase tabla temporal para poder llenarla con los datos
                DataTable tabla = new DataTable();

                // llena la variable tabla con los datos que traimos de data
                data.Fill(tabla);

                if (tabla.Rows.Count > 0)
                {
                    // aterrizar datos del primer dato.
                    modelData.id = int.Parse(tabla.Rows[0]["id"].ToString());
                    modelData.name = tabla.Rows[0]["name"].ToString();
                    modelData.second_name = tabla.Rows[0]["second_name"].ToString();
                    modelData.document_type = tabla.Rows[0]["document_type"].ToString();
                    modelData.identity = int.Parse(tabla.Rows[0]["identity"].ToString());
                    modelData.serial_number = tabla.Rows[0]["serial_number"].ToString();
                }
                return modelData;
            }
            catch (Exception ex)
            {

               throw new Exception("Algo fallo en la conexion a base de datos!" + ex.ToString());
            }           
        }
    }
}
