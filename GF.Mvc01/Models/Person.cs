using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GF.Mvc01.Models {
  public class Person {

    // ID, Id, PersonId
    public int Id { get; set; }

    public Family Family { get; set; }

    // auto-implemented property
    public string Name { get; set; }

    private string _Gender;

    [Display(Name="เพศ")]
    public string Gender {
      get {
        return _Gender;
      }
      set {
        if (value == "M" || value == "F") {
          _Gender = value;
        }
        else {
          throw new Exception("Invalid gender");
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
      this.Family = f;
      spouse.Family = f;

      if (this.Gender == "M") {
        f.Husband = this;
        f.Wife = spouse;
      }
      else {
        f.Husband = spouse;
        f.Wife = this;
      }

      return f;
    }

    public override bool Equals(object obj) {
      Person anotherPerson = obj as Person;
      return (this.Name == anotherPerson.Name
        && this.Gender == anotherPerson.Gender
        && this.BirthYear == anotherPerson.BirthYear);
    }
    public override int GetHashCode() {
      return this.Id; //  base.GetHashCode();
    }
  }

}
