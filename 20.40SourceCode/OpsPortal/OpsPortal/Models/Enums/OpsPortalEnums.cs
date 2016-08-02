using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Models.Enums
{
  public enum DeploymentStatusEnum
    {
        Invalid=0,
        Ready=1,
        Process=2,
        Deployed=3
    }
}