using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDobleV.Utility
{
    public static class ApiConnectionDB
    {
        static ApiConnectionDB()
        {

        }

        public static string ConnectionStringPrueba
        {
            get
            {
                var builder = new ConfigurationBuilder();

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile($"appsettings.{env}.json", optional: true);

                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("DBPruebaDobleV");
                return connectionString;
            }
        }
    }
}
