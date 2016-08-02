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
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace OpsPortal.Controllers
{
    [Authorize]
    public class ReleasePlanController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public ReleasePlanController() { }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public ReleasePlanController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;

        }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
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

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
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

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }


        // GET: ReleasePlan
        public async Task<ActionResult> Index()
        {
            return View(await db.ReleasePlanEntities.ToListAsync());
        }

        // GET: ReleasePlan/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReleasePlanEntity releasePlanEntity = await db.ReleasePlanEntities.FindAsync(id);
            if (releasePlanEntity == null)
            {
                return HttpNotFound();
            }
            return View(releasePlanEntity);
        }

        // GET: ReleasePlan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReleasePlan/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PlannedReleaseAt,DevOwner,OpsOwner,TestOwner,ProductOwner,NotificationList,NotificationCcList,ReleaseNotes,GitRepoTag,GitRepoRefTag,GitRepoCommitId,JenkinsBuildNo,RepleasePackageName,ReleaseEnv,Service,ServiceGitPath,Status,CreateBy,CreateAt,UpdateBy,UpdateAt")] ReleasePlanEntity releasePlanEntity)
        {
            if (ModelState.IsValid)
            {
                string email = UserManager.GetEmail(User.Identity.GetUserId());
                releasePlanEntity.CreateBy = releasePlanEntity.UpdateBy = email;

                db.ReleasePlanEntities.Add(releasePlanEntity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(releasePlanEntity);
        }

        // GET: ReleasePlan/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReleasePlanEntity releasePlanEntity = await db.ReleasePlanEntities.FindAsync(id);
            if (releasePlanEntity == null)
            {
                return HttpNotFound();
            }
            return View(releasePlanEntity);
        }

        // POST: ReleasePlan/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PlannedReleaseAt,DevOwner,OpsOwner,TestOwner,ProductOwner,NotificationList,NotificationCcList,ReleaseNotes,GitRepoTag,GitRepoRefTag,GitRepoCommitId,JenkinsBuildNo,RepleasePackageName,ReleaseEnv,Service,ServiceGitPath,Status,CreateBy,CreateAt,UpdateBy,UpdateAt")] ReleasePlanEntity releasePlanEntity)
        {
            if (ModelState.IsValid)
            {
                string email = UserManager.GetEmail(User.Identity.GetUserId());
                releasePlanEntity.UpdateBy = email;

                db.Entry(releasePlanEntity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(releasePlanEntity);
        }

        // GET: ReleasePlan/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReleasePlanEntity releasePlanEntity = await db.ReleasePlanEntities.FindAsync(id);
            if (releasePlanEntity == null)
            {
                return HttpNotFound();
            }
            return View(releasePlanEntity);
        }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        // POST: ReleasePlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReleasePlanEntity releasePlanEntity = await db.ReleasePlanEntities.FindAsync(id);
            db.ReleasePlanEntities.Remove(releasePlanEntity);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
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
