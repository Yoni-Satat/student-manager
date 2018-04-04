using System.Collections.Generic;
using StudentManager.Models;

namespace StudentManager.ViewModels
{
    public class GroupIndexData
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}