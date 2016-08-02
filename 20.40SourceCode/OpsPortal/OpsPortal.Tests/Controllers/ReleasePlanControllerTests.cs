using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpsPortal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using System.Net;
using OpsPortal.Entities;

namespace OpsPortal.Controllers.Tests
{
    [TestClass()]
    public class ReleasePlanControllerTests
    {
        [TestMethod()]
        public void ReleasePlanControllerTest()
        {
            ReleasePlanController controller = new ReleasePlanController();
            controller = new ReleasePlanController(controller.UserManager, controller.SignInManager);
            Assert.IsNotNull(controller);
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
            Task<ActionResult> result = controller.Details(1) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void Details_NullAgr()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Task<ActionResult> result = controller.Details(null) as Task<ActionResult>;
            Assert.IsTrue((result.Result as HttpStatusCodeResult).StatusCode == (int)HttpStatusCode.BadRequest);
        }


        [TestMethod()]
        public void Create_NullAgr()
        {
            ReleasePlanController controller = new ReleasePlanController();
            ActionResult result = controller.Create() as ActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void Create_EntityArg()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Task<ActionResult> result = controller.Create(new ReleasePlanEntity()) as Task<ActionResult>;
            Assert.IsNotNull(result.Result);
        }

        [TestMethod()]
        public void Create_EntityArg_IsValid()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Mock<ReleasePlanEntity> mock = new Mock<ReleasePlanEntity>();
            Task<ActionResult> result = controller.Create(mock.Object) as Task<ActionResult>;
            Assert.IsNotNull(result.Result);
        }

        [TestMethod()]
        public void Edit()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Task<ActionResult> result = controller.Edit(1) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void Edit_NullAgr()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Task<ActionResult> result = controller.Edit((int?)null) as Task<ActionResult>;
            Assert.IsTrue((result.Result as HttpStatusCodeResult).StatusCode == (int)HttpStatusCode.BadRequest);
        }

        [TestMethod()]
        public void Edit_EntityAgr()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Task<ActionResult> result = controller.Edit(new ReleasePlanEntity()) as Task<ActionResult>;
            Assert.IsTrue((result.Result as HttpStatusCodeResult).StatusCode == (int)HttpStatusCode.BadRequest);
        }

        [TestMethod()]
        public void Edit_EntityAgr_IsValid()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Mock<ReleasePlanEntity> mock = new Mock<ReleasePlanEntity>();
            Task<ActionResult> result = controller.Edit(mock.Object) as Task<ActionResult>;
            Assert.IsTrue((result.Result as HttpStatusCodeResult).StatusCode == (int)HttpStatusCode.BadRequest);
        }

        [TestMethod()]
        public void Delete()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Task<ActionResult> result = controller.Delete(10) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void Delete_NullAgr()
        {
            ReleasePlanController controller = new ReleasePlanController();
            Task<ActionResult> result = controller.Delete(null) as Task<ActionResult>;
            Assert.IsTrue((result.Result as HttpStatusCodeResult).StatusCode == (int)HttpStatusCode.BadRequest);
        }
    }
}