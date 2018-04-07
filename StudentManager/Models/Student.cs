using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date), Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Matriculation No.")]
        public string MatricNumber { get; set; }

        public string Gender { get; set; }
        public bool Adjustments { get; set; }
        public string Origin { get; set; }

        [Display(Name = "Year of study")]
        public int YearOfStudy { get; set; }

        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }

        public bool IsPresent { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}