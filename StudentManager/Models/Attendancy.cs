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
        public int LocationID { get; set; }

        [Display(Name = "Tutor name")]
        public string TutorName { get; set; }

        [Display(Name = "Lesson start time")]
        public DateTime? LessonStart { get; set; }

        [Display(Name = "Lesson End time")]
        public DateTime? LessonEnd { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}