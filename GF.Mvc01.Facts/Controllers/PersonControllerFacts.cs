using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using GF.Mvc01.Controllers;
using System.Web.Mvc;
using GF.Mvc01.Models;
using Moq;
using GF.Mvc01.DataAccess;

namespace GF.Mvc01.Facts.Controllers {
  public class PersonControllerFacts {

    public class TheIndexAction {

      [Fact]
      public void ShouldSendListOfPersonToView() {
        var repo = new Mock<IPersonRepo>();
        repo
          .Setup(x => x.GetAllPeople())
          .Returns(new List<Person>() {
            new Person() { Id =1, Name = "Mr.A", Gender = "M", BirthYear=1900 },
            new Person() {Id=2, Name="Ms.B", Gender="F",BirthYear = 1905}
          }.AsQueryable());        
        var c = new PersonController(repo.Object);
        var result = c.Index() as ViewResult;
        Assert.NotNull(result.Model);
        Assert.IsType<List<Person>>(result.Model);

        repo.Verify(x => x.GetAllPeople());
        Assert.Equal(2, ((List<Person>)(result.Model)).Count);
      }
    }

    public class TheGetAllPossibleSpousesMethod {
      [Fact]
      public void ShouldReturnValidSpourses() {
        var repo = new Mock<IPersonRepo>();
        
        var c = new PersonController();

      }
    }
    public class TheMarryAction {
    
    }
  }
}
