using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GF.Mvc01.Models;

namespace GF.Mvc01.DataAccess {
  public interface IPersonRepo {
    List<Person> GetAllPeople();
  }
}
