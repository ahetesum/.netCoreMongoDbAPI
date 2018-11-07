using BannerMongoApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BannerMongoApp.Data
{
    public class ObjectContext
    {
        public IConfiguration Configuration { get; }
        private IMongoDatabase _database = null;
        public ObjectContext(IOptions<Settings> settings)
        {
            Configuration = settings.Value.iConfiguration;
            settings.Value.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            settings.Value.Database = Configuration.GetSection("MongoConnection:Database").Value;

            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Banner> Banners
        {
            get
            {
                return _database.GetCollection<Banner>("Banner");
            }
        }

    }
}
