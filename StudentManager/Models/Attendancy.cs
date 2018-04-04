using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Models
{
    public class Attendancy
    {
        public int AttendancyID { get; set; }

        [Display(Name = "Tutor Name")]
        public string TutorName { get; set; }

        [Display(Name = "Location")]
        public int LessonLocationID { get; set; }

        [Display(Name = "Lesson Topic")]
        public string LessonTopic { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Mark Presesnt")]
        public bool IsPresent { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }


        public virtual ICollection<Group> Groups { get; set; }
    }
}