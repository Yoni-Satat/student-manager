using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManager.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPresent { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MatricNumber { get; set; }
        public string Gender { get; set; }
        public bool Adjustments { get; set; }
        public string Origin { get; set; }
        public int YearOfStudy { get; set; }
        public string ImageURL { get; set; }

        public virtual Group Group { get; set; }
    }
}