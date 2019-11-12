using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolModel.Core
{
    public class Classroom
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string TutorName { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
    }
}
