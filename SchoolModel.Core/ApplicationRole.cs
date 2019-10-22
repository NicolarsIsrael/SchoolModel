using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolModel.Core
{
    public class ApplicationRole:IdentityRole
    {
        public ApplicationRole():base()
        {

        }
        public ApplicationRole(string roleName):base(roleName)
        {
        }
    }
}
