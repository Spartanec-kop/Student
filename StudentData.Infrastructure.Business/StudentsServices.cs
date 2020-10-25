using StudentData.Domain.Core;
using StudentData.Domain.Interfaces;
using StudentData.Services.Interfaces;
using StudentData.Services.Interfaces.Models;
using System;
using System.Collections.Generic;

namespace StudentData.Infrastructure.Business
{
    public class StudentsServices : IStudentsServices
    {
        IRepository<Student> repositoryStudent;
        public StudentsServices(IRepository<Student> repository)
        {
            repositoryStudent = repository;
        }
        public void Create(Student student)
        {
            repositoryStudent.Create(student);
            repositoryStudent.Save();
        }
        public void Update(Student student)
        {
            repositoryStudent.Update(student);
            repositoryStudent.Save();
        }

        public void Delete(int id)
        {
            repositoryStudent.Delete(id);
            repositoryStudent.Save();
        }

        public IEnumerable<Student> GetStudents(StudentFilters filters, int firstItem, int pageCount)
        {
            throw new NotImplementedException();
        }      
    }
}
