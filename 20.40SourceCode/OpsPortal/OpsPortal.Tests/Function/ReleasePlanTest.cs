using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpsPortal.Controllers;
using OpsPortal.Entities;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace OpsPortal.Tests.Function
{
    [TestClass]
    public class ReleasePlanTest
    {
        int releasePlanID = 0;

        [TestMethod]
        public void Create()
        {
            ReleasePlanController controller = new ReleasePlanController();

            string str = "1";
            ReleasePlanEntity entity = new ReleasePlanEntity() { CreateAt = DateTime.Now, CreateBy = str, DevOwner = str, GitRepoCommitId = str, GitRepoRefTag = str, GitRepoTag = str, Id = 1, JenkinsBuildNo = 1, NotificationCcList = str, NotificationList = str, OpsOwner = str, PlannedReleaseAt = DateTime.Now, ProductOwner = str, ReleaseEnv = str, ReleaseNotes = str, RepleasePackageName = str, Service = str, ServiceGitPath = str, Status = 1, TestOwner = str, UpdateAt = DateTime.Now, UpdateBy = str };
            Task<ActionResult> result = controller.Create(entity) as Task<ActionResult>;
            releasePlanID = entity.Id;
            Assert.IsNotNull(result.Result);
        }


        [TestMethod()]
        public void Index()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Task<ActionResult> result = controller.Index() as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void Details()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Task<ActionResult> result = controller.Details(releasePlanID) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }
    }
}
