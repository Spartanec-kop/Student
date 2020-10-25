using StudentData.Domain.Core;
using StudentData.Domain.Interfaces;
using StudentData.Services.Interfaces;
using StudentData.Services.Interfaces.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentData.Infrastructure.Business
{
    public class GroupsServices : IGroupsServices
    {
        IRepository<Group> repositoryGroup;
        public GroupsServices(IRepository<Group> repository)
        {
            repositoryGroup = repository;
        }
        public void Create(Group group)
        {
            repositoryGroup.Create(group);
            repositoryGroup.Save();
        }

        public void Update(Group group)
        {
            repositoryGroup.Update(group);
            repositoryGroup.Save();
        }

        public void Delete(Int64 id)
        {
            repositoryGroup.Delete(id);
            repositoryGroup.Save();
        }

        public async Task<PagedViewModel<GroupView>> GetGroups(string name, int pageNumber, int pageSize)
        {
            Expression<Func<Group, bool>> predicat = s =>
            (string.IsNullOrEmpty(name) || s.Name.Contains(name));


            var count = await repositoryGroup.recordCount(predicat);
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

            List<GroupView> rows = repositoryGroup.Find(predicat)
                .Skip(skip)
                .Take(pageSize)
                .Select(r => new GroupView
                {
                    Id = r.Id,
                    Name = r.Name,
                    StudentCount = r.StudentGroups.Count()
                }
                )
                .ToList();

            var pagedGroups = new PagedViewModel<GroupView>
            {
                Rows = rows,
                TotalCount = count,
                PageSize = pageSize,
                PageNumber = pageNumber,
                PageCount = pageCount
            };
            return pagedGroups;
        }

        public IEnumerable<Group> GetStudents(string name, int firstItem, int pageCount)
        {
            throw new NotImplementedException();
        }
    }
}
