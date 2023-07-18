
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CRUDUser.Dao
{
    public class Conector
    {
        private IConfiguration configuration;
        public string ConectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            configuration = builder.Build();
            return configuration.GetConnectionString("conectionSQLServer");
        }

    }
}
