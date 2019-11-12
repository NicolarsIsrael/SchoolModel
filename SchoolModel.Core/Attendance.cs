using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolModel.Core
{
    public class Attendance
    {
        public int Id { get; set; }
        [Required]
        public DateTime AttendanceDate { get; set; }
        [Required]
        public Classroom Classroom { get; set; }
        [Display(Name ="Present students")]
        public string PresetStudentMatricNumber { get; set; }
    }
}
