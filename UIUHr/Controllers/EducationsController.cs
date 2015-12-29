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
using Microsoft.Reporting.WebForms;
using System.IO;

namespace UIUHr.Controllers
{
    public class EducationsController : Controller
    {
        private HrDBEntities db = new HrDBEntities();

        // GET: Educations
        public async Task<ActionResult> Index()
        {
            var educations = db.Educations.Include(e => e.Employee);
            return View(await educations.ToListAsync());
        }
       

        // GET: Educations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = await db.Educations.FindAsync(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // GET: Educations/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName");
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Institute,Degree,Result,PassingYear,Board,EmployeeId")] Education education)
        {
            if (ModelState.IsValid)
            {
                db.Educations.Add(education);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", education.EmployeeId);
            return View(education);
        }

        // GET: Educations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = await db.Educations.FindAsync(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", education.EmployeeId);
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Institute,Degree,Result,PassingYear,Board,EmployeeId")] Education education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", education.EmployeeId);
            return View(education);
        }

        // GET: Educations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = await db.Educations.FindAsync(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Education education = await db.Educations.FindAsync(id);
            db.Educations.Remove(education);
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
