using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Models
{
    public class Attendancy
    {
        public int AttendancyID { get; set; }

        [Display(Name = "Mark Present")]
        public bool IsPresent { get; set; }

        [Display(Name = "Comments"), DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}