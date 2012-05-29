using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using GF.Mvc01.Controllers;
using System.Web.Mvc;

namespace GF.Mvc01.Facts.Controllers {
  public class HomeControllerFacts {

    public class TheIndexAction {

      // must add refrence to System.Web.Mvc (4.0)
      [Fact]
      public void ShouldReturnViewResult() {
        var c = new HomeController();
        var result = c.Index();
        Assert.IsType<ViewResult>(result);
      }
    
    }

  }
}
