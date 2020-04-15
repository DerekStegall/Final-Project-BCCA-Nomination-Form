using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NominationFormsController : Controller
    {
        private NominationFormEntities db = new NominationFormEntities();


        // GET: NominationForms
        public ActionResult Index()
        {

            return View(db.NominationForms.ToList());

        }

        // GET: NominationForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominationForm nominationForm = db.NominationForms.Find(id);
            if (nominationForm == null)
            {
                return HttpNotFound();
            }
            return View(nominationForm);
        }

        // GET: NominationForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NominationForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nominator,email,schoolDistrict,position,relationship,nominee,age,contactInfo,graduationDate")] NominationForm nominationForm)
        {
            if (ModelState.IsValid)
            {
                nominationForm.accepted = false;
                db.NominationForms.Add(nominationForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nominationForm);
        }

        // GET: NominationForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominationForm nominationForm = db.NominationForms.Find(id);
            if (nominationForm == null)
            {
                return HttpNotFound();
            }
            return View(nominationForm);
        }

        // POST: NominationForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nominator,email,schoolDistrict,position,relationship,nominee,age,contactInfo,graduationDate,accepted")] NominationForm nominationForm)
        {
            if (ModelState.IsValid)
            {

                //db.Entry(nominationForm.accepted).State = EntityState.Unchanged;
                db.Entry(nominationForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nominationForm);
        }

        // GET: NominationForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NominationForm nominationForm = db.NominationForms.Find(id);
            if (nominationForm == null)
            {
                return HttpNotFound();
            }
            return View(nominationForm);
        }

        // POST: NominationForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NominationForm nominationForm = db.NominationForms.Find(id);
            db.NominationForms.Remove(nominationForm);
            db.SaveChanges();
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

        public ActionResult Accepted(NominationForm nominationForm, int? id)
        {
            nominationForm = db.NominationForms.Find(id);
            if (ModelState.IsValid)
            {
                nominationForm.accepted = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nominationForm);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                using (NominationFormEntities db = new NominationFormEntities())
                {
                    var obj = db.Users.Where(a => a.userName.Equals(user.userName) && a.password.Equals(user.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Id"] = obj.Id.ToString();
                        Session["userName"] = obj.userName.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(user);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}
