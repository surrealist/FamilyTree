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
    public PersonController(IPersonRepo repo) {
      this.repo = repo;
    }

    public ActionResult Index() {
      var people = repo.GetAllPeople(); 
      return View(people);
    }

  }
}
