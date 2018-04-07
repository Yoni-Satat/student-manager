using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        public string Building { get; set; }

        [Display(Name = "Room Number")]
        public double RoomNumber { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        // In View: Html.EditorFor(m => m.Notes)
    }
}