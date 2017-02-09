using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndianaJonesBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IndianaJonesBlog.Controllers
{
    public class ExperiencesController : Controller
    {
        private BlogContext db = new BlogContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Experiences.ToList());
        }

        public IActionResult Create()
        {
            //ViewBag.People = db.Persons.ToList();
            //ViewBag.PersonList = new SelectList(db.Persons, "PersonId", "Name");
            ViewBag.ListOfPeople = db.Persons.ToList();
            ViewBag.ListOfLocations = db.Locations.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Experience experience)
        {


            db.Experiences.Add(experience);
            db.SaveChanges();

            //foreach (var personId in peopleIds)
            //{
            //    db.ExperiencesPersons.Add(new ExperiencePerson(experience.ExperienceId, personId));
            //}

            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
