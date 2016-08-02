using OpsPortal.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Entities
{
    public class ReleaseJobEntity : IEntity
    {
        public int Id { get; set; }

        public int ReleasePlanEntityId { get; set; }

        public DeploymentStatusEnum DeploymentStatus { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public string DeploymentLogPath { get; set; }

        public string DeployServicePath { get; set; }

        public string DeployPackageArchivePath { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateAt { get; set; }

        public string UpdateBy { get; set; }

        public DateTime UpdateAt { get; set; }

        public virtual ReleasePlanEntity ReleasePlanEntity { get; set; }

        public ReleaseJobEntity()
        {
            DeploymentLogPath = DeployServicePath = DeployPackageArchivePath = CreateBy = UpdateBy = string.Empty;
            ReleasePlanEntityId =  0;
            DeploymentStatus = DeploymentStatusEnum.Ready;
            UpdateAt = CreateAt = StartAt = FinishedAt = DateTime.MinValue;
        }
    }
}