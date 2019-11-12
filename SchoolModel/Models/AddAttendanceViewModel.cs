using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolModel.Models
{
    public class AddAttendanceViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }
        [Required]
        public string Classroom { get; set; }
        [Display(Name = "Present students")]
        public string PresetStudentMatricNumber { get; set; }

    }
}
