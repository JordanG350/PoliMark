using maasapp.core.ConnectionSwagger.models;
using maasapp.core.PoliMark.models;
using maasapp.infrastructure.Data;
using maasapp.infrastructure.Data.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace maasapp.core.ConnectionSwagger
{
    public class PoliMark : IPoliMark
    {
        private readonly IconnectionPostgresql _db;
        private readonly IConfiguration _config;
        public PoliMark(IconnectionPostgresql postgresql, IConfiguration configuration)
        {
            _db = postgresql;
            _config = configuration;
        }

        public async Task<ModelDataProduct> GetProduct(CreationModel data)
        {
            ModelDataProduct product = new ModelDataProduct();
            return product;
        }
        public async Task<ModelDataSupplier> GetSupplier(CreationModel data)
        {
            ModelDataSupplier supplier = new ModelDataSupplier();
            return supplier;
        }

        public async Task<ModelDataClient> GetClient(CreationModel data)
        {
            ModelDataClient client = new ModelDataClient();
            return client;
        }

    }
}
