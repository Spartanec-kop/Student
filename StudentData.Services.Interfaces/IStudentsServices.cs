using StudentData.Domain.Core;
using StudentData.Infrastructure.Business.ViewModel;
using StudentData.Services.Interfaces.Models;
using StudentData.Services.Interfaces.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Services.Interfaces
{
    public interface IStudentsServices
    {
        Task<PagedViewModel<StudentView>> GetStudents(StudentFilters filters, int pageNumber, int pageSize);
        void Create(Student student);
        void Update(Student student);
        void Delete(Int64 id);
    }
}
