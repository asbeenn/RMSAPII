using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AppSettings
    {
        public string DefaultConnectionString { get; set; }
        //public string RemoteConnectionString { get; set; }
        public string? JwtKey { get; set; }
        public string? JwtExpireDays { get; set; }
        public string? JwtIssuer { get; set; }
        public string? JwtAudience { get; set; }
        public string? AllowedOrigin { get; set; }


    }
}
