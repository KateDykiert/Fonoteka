using Fonoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fonoteka.Controllers
{
    public class HomeController : Controller
    {
        private ZespolDBEntities _db = new ZespolDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Zespol.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            
        
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] Zespol zespolToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Zespol.Add(zespolToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var zespolToEdit = (from z in _db.Zespol where z.IdZespolu == id select z).First();
            return View(zespolToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Zespol zespolToEdit)
        {
            var originalZespol = (from z in _db.Zespol where z.IdZespolu == zespolToEdit.IdZespolu select z).First();
            if (!ModelState.IsValid)
                return View(originalZespol);

            _db.Entry(originalZespol).CurrentValues.SetValues(zespolToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
