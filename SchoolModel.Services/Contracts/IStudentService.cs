using System;
using System.Collections.Generic;
using System.Text;
using SchoolModel.Core;

namespace SchoolModel.Services.Contracts
{
    public interface IStudentService
    {
        void CreateStudent(Student student);
        void UpdateStudent(Student student);

        IEnumerable<Student> GetAllStudent();

        Student GetStudentById(long Id);

        void DeleteStudent(Student student);
    }
}
