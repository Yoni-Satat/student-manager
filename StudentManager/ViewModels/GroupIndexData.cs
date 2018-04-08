using System.Collections.Generic;
using StudentManager.Models;

namespace StudentManager.ViewModels
{
    public class GroupIndexData
    {
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public Course Course { get; set; }
     }
}