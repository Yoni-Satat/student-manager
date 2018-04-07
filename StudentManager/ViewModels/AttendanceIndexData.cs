using System.Collections.Generic;
using StudentManager.Models;

namespace StudentManager.ViewModels
{
    public class AttendanceIndexData
    {
        public IEnumerable<Attendancy> attendancies { get; set; }
        public IEnumerable<Location> locations { get; set; }
        public IEnumerable<Lesson> Lessons { get; set; }
        public IEnumerable<Student> students { get; set; }
    }
}