using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GF.Mvc01.Models {
  public class Person {
    public int Id { get; set; }

    public Family Family { get; set; }

    // auto-implemented property
    public string Name { get; set; }

    private string _Gender;
    public string Gender {
      get {
        return _Gender;
      }
      set {
        if (value == "M" || value == "F") {
          _Gender = value;
        }
        else {
          throw new Exception();
        }
      }
    }

    // standard property
    private int _BirthYear;
    public int BirthYear {
      get {
        return _BirthYear;
      }
      set {
        if (value <= DateTime.Now.Year) {
          _BirthYear = value;
        }
        else {
          throw new Exception();
        }
      }
    }


    public int GetAge() {
      return DateTime.Now.Year - this.BirthYear;
    }

    public Family Marry(Person spouse) {
      if (this.GetAge() < 20 || spouse.GetAge() < 20) {
        throw new Exception();
      }
      if (this.Gender == spouse.Gender) {
        throw new Exception();
      }
      Family f = new Family();
      return f;
    }
  }

}
