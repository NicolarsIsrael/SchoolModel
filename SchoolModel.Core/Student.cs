﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolModel.Core
{
    public class Student
    {
        public long Id { get; set; }
        [Display(Name ="First name")]
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Full name must be atleast 2 characters long and not more than 25 characters")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Last name must be atleast 2 characters long and not more than 25 characters")]
        public string LastName { get; set; }
        [Required]
        public string MatricNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Range(16,int.MaxValue)]
        public int Age { get; set; }
        public Classroom Class { get; set; }
        public Parent Parent { get; set; }

    }
}
