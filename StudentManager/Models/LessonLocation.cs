using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Models
{
    public class LessonLocation
    {
        public int LessonLocationID { get; set; }
        public string Building { get; set; }

        [Display(Name = "Room Number")]
        public double RoomNumber { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        // In View: Html.EditorFor(m => m.Description)

        public virtual Lesson Lesson { get; set; }
    }
}

