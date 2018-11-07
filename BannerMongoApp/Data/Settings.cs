using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BannerMongoApp.Data
{
    public class Settings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public IConfiguration iConfiguration { get; set; }
    }
}
