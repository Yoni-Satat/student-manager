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
        public int LessonLocationID { get; set; }
        public string Topic { get; set; }

        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "Mandatory")]
        public bool IsMandatory { get; set; }  
        
        public virtual Course Course { get; set; }
        public virtual LessonLocation LessonLocation { get; set; }
        
    }
}