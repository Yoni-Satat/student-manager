using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManager.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int GroupID { get; set; }
        public int StudentID { get; set; }
        public int ? LessonID { get; set; }
        public int CourseID { get; set; }

        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Course Course { get; set; }
    }
}