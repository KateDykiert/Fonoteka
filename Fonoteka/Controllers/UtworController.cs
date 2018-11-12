using Fonoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fonoteka.Controllers
{
    public class UtworController : Controller
    {
        private UtworDBEntities _db = new UtworDBEntities();
        // GET: Utwor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Utwor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Utwor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Utwor utworToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Utwor.Add(utworToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var zespolToEdit = (from z in _db.Utwor where z.IdZespolu == id select z).First();
            return View(zespolToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Utwor zespolToEdit)
        {
            var originalZespol = (from z in _db.Utwor where z.IdZespolu == zespolToEdit.IdZespolu select z).First();
            if (!ModelState.IsValid)
                return View(originalZespol);

            _db.Entry(originalZespol).CurrentValues.SetValues(zespolToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: Zespol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utwor personalDetail = _db.Utwor.Find(id);
            if (personalDetail == null)
            {
                return HttpNotFound();
            }
            return View(personalDetail);
        }

        // POST: Zespol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utwor personalDetail = _db.Utwor.Find(id);
            _db.Utwor.Remove(personalDetail);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
