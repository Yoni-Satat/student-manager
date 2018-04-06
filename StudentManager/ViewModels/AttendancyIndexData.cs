using System.Collections.Generic;
using StudentManager.Models;

namespace StudentManager.ViewModels
{
    public class AttendancyIndexData
    {
        public IEnumerable<Attendancy> attendancies { get; set; }
        public IEnumerable<Group> groups { get; set; }
        public IEnumerable<Lesson> lessons { get; set; }
    }
}