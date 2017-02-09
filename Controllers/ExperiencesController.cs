using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndianaJonesBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create(Experience experience, int[] peopleIds)
        {


            db.Experiences.Add(experience);
            db.SaveChanges();
            foreach (var personId in peopleIds)
            {
                db.ExperiencesPersons.Add(new ExperiencePerson(experience.ExperienceId, personId));
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(e => e.ExperienceId == id);

            ViewBag.Persons = db.ExperiencesPersons
                .Include(ep => ep.Person).Where(ep => ep.ExperienceId == thisExperience.ExperienceId).Select(ep => ep.Person).ToList();


            return View(thisExperience);
        }

        public IActionResult Edit (int id)
        {

            var selectedExperience = db.Experiences.Include(e => e.ExperiencesPersons).ThenInclude(ep => ep.Person).Include(e => e.Location).FirstOrDefault(e => e.ExperienceId == id);

            ViewBag.SelectedPeople = new List<Person>();
            
            foreach(var exp in selectedExperience.ExperiencesPersons)
            {
                ViewBag.SelectedPeople.Add(exp.Person);
            }



            //var selectedExperience = db.Experiences.FirstOrDefault(e => e.ExperienceId == id);
  
            //ViewBag.SelectedPeople = db.ExperiencesPersons
            //    .Include(ep => ep.Person).Where(ep => ep.ExperienceId == selectedExperience.ExperienceId).Select(op => op.Person).ToList();
            
            ViewBag.ListOfPeople = db.Persons.ToList();

            ViewBag.ListOfLocations = db.Locations.ToList();

            return View(selectedExperience);
        }

        [HttpPost]
        public IActionResult Edit(Experience experience, int[] peopleIds)
        {


            db.Experiences.Add(experience);
            db.SaveChanges();
            foreach (var personId in peopleIds)
            {
                db.ExperiencesPersons.Add(new ExperiencePerson(experience.ExperienceId, personId));
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
