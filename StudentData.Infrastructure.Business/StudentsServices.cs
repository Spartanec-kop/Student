using StudentData.Domain.Core;
using StudentData.Domain.Interfaces;
using StudentData.Infrastructure.Business.ViewModel;
using StudentData.Services.Interfaces;
using StudentData.Services.Interfaces.Models;
using StudentData.Services.Interfaces.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            int studentCount = repositoryStudent.Find(f => f.NickName.ToLower() == student.NickName.ToLower()).Count();
            if (studentCount == 0)
            {
                repositoryStudent.Create(student);
                repositoryStudent.Save();
            } else
            {
                throw new Exception("Студент с таким позывным уже существует.");
            }
            
        }
        public async void Update(Student student)
        {
            repositoryStudent.Update(student);
            repositoryStudent.Save();
        }

        public async void Delete(Int64 id)
        {
            repositoryStudent.Delete(id);
            repositoryStudent.Save();
        }

        public async Task<PagedViewModel<StudentView>> GetStudents(StudentFilters filters, int pageNumber, int pageSize)
        {
            Expression<Func<Student, bool>> predicat = s =>
            (string.IsNullOrEmpty(filters.Fio) || (s.LastName + ' ' + s.Name + ' ' + s.MiddleName).Contains(filters.Fio))
            && (string.IsNullOrEmpty(filters.NickName) || s.NickName.Contains(filters.NickName))
            && (filters.Sex == null || s.Sex == filters.Sex);


            var count = await repositoryStudent.recordCount(predicat);
            if (pageSize < 1)
            {
                pageSize = 25;
            }
            var pageCount = (int)Math.Ceiling((double)count / pageSize);
            if (pageNumber > pageCount)
            {
                pageNumber = pageCount;
            }
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }
            var skip = (pageNumber - 1) * pageSize;

            List<StudentView> rows = repositoryStudent.Find(predicat)
                .Skip(skip)
                .Take(pageSize)
                // TODO: EF не может преобразовать это выражение в SQL, нужно подумать как сделать по другому
                .Where(s => string.IsNullOrEmpty(filters.GroupName) || String.Join(", ", s.StudentGroups.Select(g => g.Group.Name).ToList()).Contains(filters.GroupName))
                .Select(r => new StudentView
                    {
                        Id = r.Id,
                        Fio = $"{r.LastName} {r.Name} {r.MiddleName}",
                        Groups = String.Join(", ", r.StudentGroups.Select(g => g.Group.Name)),
                        NickName = r.NickName,
                        Sex = r.Sex
                    }
                )
                .ToList();

            var pagedStudents = new PagedViewModel<StudentView>
            {
                Rows = rows,
                TotalCount = count,
                PageSize = pageSize,
                PageNumber = pageNumber,
                PageCount = pageCount
            };
            return pagedStudents;
        }      
    }
}
