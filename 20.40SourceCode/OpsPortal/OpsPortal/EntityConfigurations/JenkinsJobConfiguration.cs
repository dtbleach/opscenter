using OpsPortal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OpsPortal.EntityConfigurations
{
    public class JenkinsJobConfiguration :EntityTypeConfiguration<JenkinsJobEntity>
    {
        public JenkinsJobConfiguration()
        {
            ToTable("jenkins_jobs");
            HasKey(c => c.Id);
            Property(c => c.ServiceName).HasColumnName("service_name").IsRequired();
            Property(c => c.StartTime).HasColumnName("start_at").IsRequired();
            Property(c => c.EndTime).HasColumnName("end_at").IsRequired();
            Property(c => c.LaterTime).HasColumnName("later_at").IsRequired();
            Property(c => c.Status).HasColumnName("status").IsRequired();
            Property(c => c.BuildNumber).HasColumnName("build_number").IsRequired();

        }
    }
}