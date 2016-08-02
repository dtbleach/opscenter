using OpsPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Repositories
{
    public class ReleaseJobRepository : RepositoryBase<ReleaseJobEntity>, IReleaseJobRepository
    {
        public ReleaseJobRepository(IDatabaseFactory databaseFactory)
			: base(databaseFactory)
		{

        }
    }

    public interface IReleaseJobRepository : IRepository<ReleaseJobEntity>
    {

    }
}