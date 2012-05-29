using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GF.Mvc01.DataAccess;
using GF.Mvc01.Models;

namespace GF.Mvc01.Controllers {
  public class PersonController : Controller {
    private IPersonRepo repo;

    public PersonController()
      : this(new PersonRepo()) {
      //
    }
    public PersonController(IPersonRepo repo) {
      this.repo = repo;
    }

    public ActionResult Index() {
      var people = repo.GetAllPeople().ToList();
      return View(people);
    }

    public ActionResult Create() {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Person p) {
      if (ModelState.IsValid) {
        repo.Add(p);
        return RedirectToAction("Index");
      }
      return View();
    }

    public ActionResult Edit(int id) {
      Person p = repo.GetById(id);
      return View(p);
    }
    [HttpPost]
    public ActionResult Edit(Person p) {
      if (ModelState.IsValid) {
        repo.Update(p);
        return RedirectToAction("Index");
      }
      return View();
    }

    public ActionResult Delete(int id) {
      Person p = repo.GetById(id);
      if (p == null) {
        return HttpNotFound();
      }
      return View(p);
    }

    [ActionName("Delete")]
    [HttpPost]
    public ActionResult Delete_Post(int id) {
      try {
        repo.Delete(id);
        return RedirectToAction("Index");
      }
      catch (Exception) {
        return View();
      }
    }

    public ActionResult Details(int id) {
      Person p = repo.GetById(id);
      return View(p);
    }

    [NonAction]
    public List<Person> GetAllPossibleSpouses(int id) {
      return null;
    }

    [HttpPost]
    public ActionResult Marry(int p1, int p2) {
      return null;
    }

  }
}
