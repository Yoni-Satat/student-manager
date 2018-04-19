using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManager.Models
{
    public class GroupAttendancy
    {
        [Key, Column(Order = 0), ForeignKey("Group")]
        public int GroupID { get; set; }

        [Key, Column(Order = 1), ForeignKey("Attendancy")]
        public int AttendancyID { get; set; }

        public Group Group { get; set; }
        public Attendancy Attendancy { get; set; }

        public string StudentName { get; set; }
        public string TutorName { get; set; }
        public Location Location { get; set; }

        [DataType(DataType.MultilineText)]
        public string notes { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

    }
}