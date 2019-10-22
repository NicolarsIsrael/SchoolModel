using System;
using System.Collections.Generic;
using System.Text;
using SchoolModel.Data.Implementations;
using SchoolModel.Services.Contracts;
using SchoolModel.Core;

namespace SchoolModel.Services.Implementations
{
    public class StudentService : IStudentService
    {
        UnitOfWork uow;
        public StudentService(UnitOfWork _uow)
        {
            if (uow == null)
                uow = _uow;
        }

        public void CreateStudent(Student student)
        {
            uow.StudentDao.Add(student);
            uow.Save();
        }

        public void UpdateStudent(Student student)
        {
            uow.StudentDao.Update(student);
            uow.Save();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return uow.StudentDao.GetAll();
        }

        public Student GetStudentById(long Id)
        {
            return uow.StudentDao.Get(Id);
        }

        public void DeleteStudent(Student student)
        {
            uow.StudentDao.Remove(student);
            uow.Save();
        }
    }
}
