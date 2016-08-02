using OpsPortal.App_Start;
using OpsPortal.Entities;
using OpsPortal.EntityConfigurations;
using OpsPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpsPortal.Repositories
{
    public class BmwOneOpsCenterEntities
    {
        public BmwOneOpsCenterEntities() 
		{
        }

        //public DbSet<ReleasePlanEntity> ReleasePlans { get; set; }
        //public DbSet<ReleaseJobEntity> ReleaseJobs { get; set; }

        //public virtual void Commit()
        //{
        //    try
        //    {
        //        SaveChanges();
        //    }
        //    catch
        //    {
        //        // TODO:
        //        throw;
        //    }
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // http://stackoverflow.com/questions/5532810/entity-framework-code-first-defining-relationships-keys
        //    // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        //    modelBuilder.Configurations.Add(new ReleasePlanConfiguration());
        //    modelBuilder.Configurations.Add(new ReleaseJobConfiguration());
        //}


  
    }
    }