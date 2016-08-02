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

namespace OpsPortal.Controllers
{
    [Authorize]
    public class JenkinsJobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JenkinsJob
        public async Task<ActionResult> Index()
        {
            return View(await db.JenkinsJobEntities.ToListAsync());
        }

        // GET: JenkinsJob/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JenkinsJobEntity jenkinsJobEntity = await db.JenkinsJobEntities.FindAsync(id);
            if (jenkinsJobEntity == null)
            {
                return HttpNotFound();
            }
            return View(jenkinsJobEntity);
        }

        // GET: JenkinsJob/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JenkinsJob/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ServiceName,StartTime,EndTime,LaterTime,BuildNumber,Status")] JenkinsJobEntity jenkinsJobEntity)
        {
            if (ModelState.IsValid)
            {
                db.JenkinsJobEntities.Add(jenkinsJobEntity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jenkinsJobEntity);
        }

        // GET: JenkinsJob/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JenkinsJobEntity jenkinsJobEntity = await db.JenkinsJobEntities.FindAsync(id);
            if (jenkinsJobEntity == null)
            {
                return HttpNotFound();
            }
            return View(jenkinsJobEntity);
        }

        // POST: JenkinsJob/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ServiceName,StartTime,EndTime,LaterTime,BuildNumber,Status")] JenkinsJobEntity jenkinsJobEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jenkinsJobEntity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jenkinsJobEntity);
        }

        // GET: JenkinsJob/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JenkinsJobEntity jenkinsJobEntity = await db.JenkinsJobEntities.FindAsync(id);
            if (jenkinsJobEntity == null)
            {
                return HttpNotFound();
            }
            return View(jenkinsJobEntity);
        }

        // POST: JenkinsJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            JenkinsJobEntity jenkinsJobEntity = await db.JenkinsJobEntities.FindAsync(id);
            db.JenkinsJobEntities.Remove(jenkinsJobEntity);
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
