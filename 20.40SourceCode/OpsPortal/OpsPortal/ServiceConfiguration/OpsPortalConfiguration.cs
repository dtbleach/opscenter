using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OpsPortal.ServiceConfiguration
{
    public class OpsPortalConfiguration : IOpsPortalConfiguration
    {

        private const string OPSPORTAL_DB = "bmwone_opscenter_db";
        private const string AUTH_USERNAME = "opsoportal_auth_user";
        private const string AUTH_PASSWORD = "aopsoportal_auth_password";
        private const string FORCE_SSL = "force_ssl";


        public bool ForceSsl
        {
            get
            {
                var data = ConfigurationManager.AppSettings[FORCE_SSL] ?? "";
                return data.Equals("true", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public string OpsPortalDbConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[OPSPORTAL_DB].ConnectionString;
            }
        }

        public string AuthUsername
        {
            get
            {
                return ConfigurationManager.AppSettings[AUTH_USERNAME];
            }
        }

        public string AuthPassword
        {
            get
            {
                return ConfigurationManager.AppSettings[AUTH_PASSWORD];
            }
        }
    }
}