using OpsPortal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpsPortal.EntityConfigurations
{
    public class ReleasePlanConfiguration: EntityTypeConfiguration<ReleasePlanEntity>
    {
        public ReleasePlanConfiguration()
        {
            ToTable("release_plans");
            HasKey(c => c.Id);

            Property(c => c.PlannedReleaseAt).HasColumnName("planned_release_at").IsRequired();
            Property(c => c.DevOwner).HasColumnName("dev_owner").IsRequired();
            Property(c => c.OpsOwner).HasColumnName("ops_owner").IsRequired();
            Property(c => c.TestOwner).HasColumnName("test_owner").IsRequired();
            Property(c => c.ProductOwner).HasColumnName("product_owner").IsRequired();
            Property(c => c.NotificationList).HasColumnName("notification_list").IsRequired();
            Property(c => c.NotificationCcList).HasColumnName("notification_cc_list").IsRequired();
            Property(c => c.ReleaseNotes).HasColumnName("release_notes").IsRequired();
            Property(c => c.GitRepoTag).HasColumnName("git_repo_tag").IsRequired();
            Property(c => c.GitRepoRefTag).HasColumnName("git_repo_ref_tag").IsRequired();
            Property(c => c.GitRepoCommitId).HasColumnName("git_repo_commit_id").IsRequired();
            Property(c => c.JenkinsBuildNo).HasColumnName("jenkins_build_no").IsRequired();
            Property(c => c.RepleasePackageName).HasColumnName("replease_package_name").IsRequired();
            Property(c => c.ReleaseEnv).HasColumnName("release_env").IsRequired();
            Property(c => c.Service).HasColumnName("service").IsRequired();
            Property(c => c.ServiceGitPath).HasColumnName("service_git_path").IsRequired();
            Property(c => c.Status).HasColumnName("status").IsRequired();
            Property(c => c.CreateBy).HasColumnName("create_by").IsRequired();
            Property(c => c.CreateAt).HasColumnName("create_at").IsRequired();
            Property(c => c.UpdateBy).HasColumnName("update_by").IsRequired();
            Property(c => c.UpdateAt).HasColumnName("update_at").IsRequired();


        }

    }
}