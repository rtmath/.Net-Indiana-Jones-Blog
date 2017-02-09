using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndianaJonesBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace IndianaJonesBlog.Controllers
{
    public class PersonsController : Controller
    {
        private BlogContext db = new BlogContext();

        public IActionResult Index()
        {
            return View(db.Persons.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person newPerson)
        {
            db.Persons.Add(newPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisPerson = db.Persons.FirstOrDefault(l => l.PersonId == id);
            return View(thisPerson);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisPerson = db.Persons.FirstOrDefault(persons => persons.PersonId == id);
            return View(thisPerson);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPerson = db.Persons.FirstOrDefault(persons => persons.PersonId == id);
            db.Persons.Remove(thisPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
