using OpsPortal.Entities;
using OpsPortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Repositories
{
    public class ReleasePlanRepository: RepositoryBase<ReleasePlanEntity>, IReleasePlanRepository
    {
        public ReleasePlanRepository(IDatabaseFactory databaseFactory)
			: base(databaseFactory)
		{

        }
    }

    public interface IReleasePlanRepository : IRepository<ReleasePlanEntity>
    {
    }
}