using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Models
{
    public class Group
    {
        public int GroupID { get; set; }

        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Display(Name = "Group Title")]
        public string GroupTitle { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}