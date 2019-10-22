using System;
using System.Collections.Generic;
using System.Text;
using SchoolModel.Core;
using SchoolModel.Data.Contracts;

namespace SchoolModel.Data.Implementations
{
    public class StudentDao : CoreDao<Student>,IStudentDao
    {
        public StudentDao(SchoolContextData ctx): base(ctx)
        {

        }
    }
}
