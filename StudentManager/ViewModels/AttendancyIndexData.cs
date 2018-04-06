using System.Collections.Generic;
using System.Linq;
using StudentManager.Models;

namespace StudentManager.ViewModels
{
    public class AttendancyIndexData
    {
        public IEnumerable<Attendancy> Attendancies { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Lesson> Lessons { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}