using OpsPortal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpsPortal.EntityConfigurations
{
    public class ReleaseJobConfiguration :EntityTypeConfiguration<ReleaseJobEntity>
    {
        public ReleaseJobConfiguration()
        {
            ToTable("release_jobs");
            HasKey(c => c.Id);
            Property(c => c.ReleasePlanEntityId).HasColumnName("release_plan_id").IsRequired();
            Property(c => c.DeploymentStatus).HasColumnName("deployment_status").IsRequired();
            Property(c => c.StartAt).HasColumnName("start_at").IsRequired();
            Property(c => c.FinishedAt).HasColumnName("finished_at").IsRequired();
            Property(c => c.DeploymentLogPath).HasColumnName("deployment_log_path").IsRequired();
            Property(c => c.DeployServicePath).HasColumnName("deployment_service_path").IsRequired();
            Property(c => c.DeployPackageArchivePath).HasColumnName("deployment_package_archive_path").IsRequired();
            Property(c => c.CreateBy).HasColumnName("create_by").IsRequired();
            Property(c => c.CreateAt).HasColumnName("create_at").IsRequired();
            Property(c => c.UpdateBy).HasColumnName("update_by").IsRequired();
            Property(c => c.UpdateAt).HasColumnName("update_at").IsRequired();
            HasRequired(c => c.ReleasePlanEntity).WithMany();
            

        }
    }
}