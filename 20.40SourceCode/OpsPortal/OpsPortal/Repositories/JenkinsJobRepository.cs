using OpsPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Repositories
{
    public class JenkinsJobRepository : RepositoryBase<JenkinsJobEntity>, IJenkinsJobRepository
    {
        public JenkinsJobRepository(IDatabaseFactory databaseFactory)
			: base(databaseFactory)
		{

        }
    }

    public interface IJenkinsJobRepository : IRepository<JenkinsJobEntity>
    {

    }
}