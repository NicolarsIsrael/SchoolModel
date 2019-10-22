using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolModel.Core
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser(): base (){  }
        public string FullName { get; set; }
        public int Age { get; set; }

       
    }
}
