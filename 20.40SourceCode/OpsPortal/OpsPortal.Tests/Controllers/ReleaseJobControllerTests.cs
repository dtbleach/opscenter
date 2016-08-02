using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpsPortal.Controllers;
using OpsPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpsPortal.Controllers.Tests
{
    [TestClass()]
    public class ReleaseJobControllerTests
    {
        [TestMethod()]
        public void ReleaseJobControllerTest()
        {
            ReleaseJobController controller = new ReleaseJobController();
            controller = new ReleaseJobController(controller.UserManager, controller.SignInManager);
            Assert.IsNotNull(controller);
        }


        [TestMethod()]
        public void IndexTest()
        {
            ReleaseJobController controller = new ReleaseJobController();
            Task<ActionResult> result = controller.Index() as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            ReleaseJobController controller = new ReleaseJobController();
            Task<ActionResult> result = controller.Details(1) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest()
        {
            ReleaseJobController controller = new ReleaseJobController();
            ActionResult result = controller.Create() as ActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest_Entity()
        {
            ReleaseJobController controller = new ReleaseJobController();
            Task<ActionResult> result = controller.Create(It.IsAny<ReleaseJobEntity>()) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest()
        {
            ReleaseJobController controller = new ReleaseJobController();
            Task<ActionResult> result = controller.Edit(1) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest_Entity()
        {
            ReleaseJobController controller = new ReleaseJobController();
            Task<ActionResult> result = controller.Edit(It.IsAny<ReleaseJobEntity>()) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

  
    }
}