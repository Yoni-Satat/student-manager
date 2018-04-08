using System.Collections.Generic;
using StudentManager.Models;

namespace StudentManager.ViewModels
{
    public class CourseIndexData
    {
        

        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Lesson> Lessons { get; set; }
    }
}