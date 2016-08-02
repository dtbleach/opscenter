using OpsPortal.Core;
using OpsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Repositories
{
    public class OpsPortalDatabaseFactory : Disposable, IDatabaseFactory
    {
        private ApplicationDbContext dataContext;

        public ApplicationDbContext Get()
        {
            return dataContext ?? (dataContext = new ApplicationDbContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }

    public interface IDatabaseFactory : IDisposable
    {
        ApplicationDbContext Get();
    }
}