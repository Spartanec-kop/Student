using StudentData.Domain.Core;
using StudentData.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Services.Interfaces
{
    public interface IStudentsServices
    {
        IEnumerable<Student> GetStudents(StudentFilters filters, int firstItem, int pageCount);
        void Create(Student student);
        void Update(Student student);
        void Delete(int id);
    }
}
