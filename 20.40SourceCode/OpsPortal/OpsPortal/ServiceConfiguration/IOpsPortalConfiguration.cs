using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.ServiceConfiguration
{
    public interface IOpsPortalConfiguration
    {
        bool ForceSsl { get; }
        string AuthUsername { get; }
        string AuthPassword { get; }
        string OpsPortalDbConnectionString { get; }
    }
}