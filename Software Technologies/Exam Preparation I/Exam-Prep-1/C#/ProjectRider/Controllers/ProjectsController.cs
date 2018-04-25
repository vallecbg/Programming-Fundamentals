﻿
using System.Linq;

namespace ProjectRider.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ProjectRider.Models;

    public class ProjectController : Controller
    {
        private readonly ProjectDbContext database;

        public ProjectController(ProjectDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var projects = database.Projects.ToList();
            return View(projects);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Project project)
        {
            database.Projects.Add(project);
            database.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var proj = database.Projects.Where(p => p.Id == id).FirstOrDefault();

            return View(proj);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Project projectModel)
        {
            database.Projects.Update(projectModel);
            database.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var proj = database.Projects.Where(p => p.Id == id).FirstOrDefault();

            return View(proj);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Project projectModel)
        {
            database.Remove(projectModel);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
