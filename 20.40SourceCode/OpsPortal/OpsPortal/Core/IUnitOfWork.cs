using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Core
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}