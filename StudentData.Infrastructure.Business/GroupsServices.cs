using StudentData.Domain.Core;
using StudentData.Domain.Interfaces;
using StudentData.Services.Interfaces;
using System;
using System.Collections.Generic;

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

        public IEnumerable<Group> GetGroups(string name, int firstItem, int pageCount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetStudents(string name, int firstItem, int pageCount)
        {
            throw new NotImplementedException();
        } 
    }
}
