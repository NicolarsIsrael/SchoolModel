using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolModel.Core
{
    public class Parent
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Full name")]
        [StringLength(50,MinimumLength =2,ErrorMessage ="Full name must have atleast 2 characters and not more than 50")]
        public string Fullname { get; set; }

        [Display(Name ="Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
