using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManager.Models
{
    public class Lesson
    {
        public int LessonID { get; set; }
        public string Topic { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsMandatory { get; set; }
        public int Index { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}