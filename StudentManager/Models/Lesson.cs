using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Models
{
    public class Lesson
    {
        public int LessonID { get; set; }
        public int CourseID { get; set; }
        public int? LocationID { get; set; }
        public int? AttendancyID { get; set; }

        public string Topic { get; set; }

        [Display(Name = "Schedule to start")]
        public DateTime? LessonStart { get; set; }

        [Display(Name = "Schedule to end")]
        public DateTime? LessonEnd { get; set; }

        [Display(Name = "Mark Mandatory")]
        public bool IsMandatory { get; set; }  
        
        public virtual Course Course { get; set; }
        public virtual Location Location { get; set; }     
        public virtual Attendancy Attendancy { get; set; }
    }
}