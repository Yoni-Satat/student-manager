using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Models
{
    public class LessonLocation
    {
        public int LessonLocationID { get; set; }
        public int LessonID { get; set; }
        public string Address { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}