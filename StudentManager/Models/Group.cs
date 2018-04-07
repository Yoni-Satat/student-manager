﻿using System;
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
        public int CourseID { get; set; }

        [Display(Name = "Group Title")]
        public string GroupTitle { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Attendancy> Attendances { get; set; }
        public virtual ICollection<Student> Students { get; set; }        
    }
}