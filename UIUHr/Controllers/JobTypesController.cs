using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UIUHr.Models;

namespace UIUHr.Controllers
{
    public class JobTypesController : Controller
    {
        private HrDBEntities db = new HrDBEntities();

        // GET: JobTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.JobTypes.ToListAsync());
        }

        // GET: JobTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobType jobType = await db.JobTypes.FindAsync(id);
            if (jobType == null)
            {
                return HttpNotFound();
            }
            return View(jobType);
        }

        // GET: JobTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] JobType jobType)
        {
            if (ModelState.IsValid)
            {
                db.JobTypes.Add(jobType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jobType);
        }

        // GET: JobTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobType jobType = await db.JobTypes.FindAsync(id);
            if (jobType == null)
            {
                return HttpNotFound();
            }
            return View(jobType);
        }

        // POST: JobTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] JobType jobType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobType);
        }

        // GET: JobTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobType jobType = await db.JobTypes.FindAsync(id);
            if (jobType == null)
            {
                return HttpNotFound();
            }
            return View(jobType);
        }

        // POST: JobTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            JobType jobType = await db.JobTypes.FindAsync(id);
            db.JobTypes.Remove(jobType);
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
