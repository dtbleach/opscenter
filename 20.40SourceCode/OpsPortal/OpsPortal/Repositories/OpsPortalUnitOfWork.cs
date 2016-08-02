using OpsPortal.Core;
using OpsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Repositories
{
    public class OpsPortalUnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private ApplicationDbContext dataContext;

        public OpsPortalUnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected ApplicationDbContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}