using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpsPortal.Entities;
using OpsPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OpsPortal.Models.Enums;

namespace OpsPortal.Controllers
{
    [Authorize]
    public class ReleaseJobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ReleaseJobController()
        {
        }

        public ReleaseJobController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;

        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }
        // GET: ReleaseJob
        public async Task<ActionResult> Index()
        {
            var releaseJobEntities = db.ReleaseJobEntities.Include(r => r.ReleasePlanEntity);
            return View(await releaseJobEntities.ToListAsync());
        }

        // GET: ReleaseJob/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReleaseJobEntity releaseJobEntity = await db.ReleaseJobEntities.FindAsync(id);
            if (releaseJobEntity == null)
            {
                return HttpNotFound();
            }
            return View(releaseJobEntity);
        }

        // GET: ReleaseJob/Create
        public ActionResult Create()
        {
            ViewBag.ReleasePlanEntityId = new SelectList(db.ReleasePlanEntities, "Id", "GitRepoTag");
            return View();
        }

        // POST: ReleaseJob/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ReleasePlanEntityId,DeploymentStatus,StartAt,FinishedAt,DeploymentLogPath,DeployServicePath,DeployPackageArchivePath,CreateBy,CreateAt,UpdateBy,UpdateAt")] ReleaseJobEntity releaseJobEntity)
        {
            if (ModelState.IsValid)
            {
                releaseJobEntity.UpdateAt = DateTime.Now;
                releaseJobEntity.CreateAt = DateTime.Now;
                string email= UserManager.GetEmail(User.Identity.GetUserId());
                releaseJobEntity.CreateBy = email;
                releaseJobEntity.UpdateBy = email;
                releaseJobEntity.DeploymentStatus = DeploymentStatusEnum.Ready;
                db.ReleaseJobEntities.Add(releaseJobEntity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ReleasePlanEntityId = new SelectList(db.ReleasePlanEntities, "Id", "GitRepoTag", releaseJobEntity.ReleasePlanEntityId);
            return View(releaseJobEntity);
        }

        // GET: ReleaseJob/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReleaseJobEntity releaseJobEntity = await db.ReleaseJobEntities.FindAsync(id);
            if (releaseJobEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReleasePlanEntityId = new SelectList(db.ReleasePlanEntities, "Id", "GitRepoTag", releaseJobEntity.ReleasePlanEntityId);
            return View(releaseJobEntity);
        }

        // POST: ReleaseJob/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ReleasePlanEntityId,DeploymentStatus,StartAt,FinishedAt,DeploymentLogPath,DeployServicePath,DeployPackageArchivePath,CreateBy,CreateAt,UpdateBy,UpdateAt")] ReleaseJobEntity releaseJobEntity)
        {
            if (ModelState.IsValid)
            {
                string email = UserManager.GetEmail(User.Identity.GetUserId());
                releaseJobEntity.UpdateAt = DateTime.Now;
                releaseJobEntity.UpdateBy = email;
                db.Entry(releaseJobEntity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ReleasePlanEntityId = new SelectList(db.ReleasePlanEntities, "Id", "GitRepoTag", releaseJobEntity.ReleasePlanEntityId);
            return View(releaseJobEntity);
        }

        // GET: ReleaseJob/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReleaseJobEntity releaseJobEntity = await db.ReleaseJobEntities.FindAsync(id);
            if (releaseJobEntity == null)
            {
                return HttpNotFound();
            }
            return View(releaseJobEntity);
        }

        // POST: ReleaseJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReleaseJobEntity releaseJobEntity = await db.ReleaseJobEntities.FindAsync(id);
            db.ReleaseJobEntities.Remove(releaseJobEntity);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
