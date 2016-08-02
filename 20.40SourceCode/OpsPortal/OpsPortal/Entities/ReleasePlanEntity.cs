using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Entities
{
    public class ReleasePlanEntity:IEntity
    {
        public int Id { get; set; }
     
        public DateTime PlannedReleaseAt { get; set; }

        public string DevOwner { get; set; }

        public string OpsOwner { get; set; }

        public string TestOwner { get; set; }

        public string ProductOwner { get; set; }

        public string NotificationList { get; set; }

        public string NotificationCcList { get; set; }

        public string ReleaseNotes { get; set; }

        public string GitRepoTag { get; set; }

        public string GitRepoRefTag { get; set; }

        public string GitRepoCommitId { get; set; }

        public int JenkinsBuildNo { get; set; }

        public string RepleasePackageName { get; set; }

        public string ReleaseEnv { get; set; }

        public string Service { get; set; }

        public string ServiceGitPath { get; set; }

        public int Status { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateAt { get; set; }

        public string UpdateBy { get; set; }

        public DateTime UpdateAt { get; set; }

        public ReleasePlanEntity()
        {
            DevOwner = OpsOwner = TestOwner = ProductOwner = NotificationList = NotificationCcList = ReleaseNotes = GitRepoTag = GitRepoRefTag = GitRepoCommitId = RepleasePackageName =
                ReleaseEnv = Service = ServiceGitPath = CreateBy = UpdateBy = string.Empty;
            JenkinsBuildNo = Status = 0;

            CreateAt = UpdateAt = DateTime.Now;
        }

    }
}