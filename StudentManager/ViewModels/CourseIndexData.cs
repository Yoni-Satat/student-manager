using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentManager.Models;
using StudentManager.Repos;

namespace StudentManager.ViewModels
{
    public class CourseIndexData
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Lesson> Lessons { get; set; }
    }
}