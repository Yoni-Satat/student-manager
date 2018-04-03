using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManager.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public int CourseID { get; set; }
        public string GroupTitle { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}