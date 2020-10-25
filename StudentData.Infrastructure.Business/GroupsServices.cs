using StudentData.Domain.Core;
using StudentData.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace StudentData.Infrastructure.Business
{
    public class GroupsServices : IGroupsServices
    {
        public IEnumerable<Group> GetStudents(string name, int firstItem, int pageCount)
        {
            throw new NotImplementedException();
        }
    }
}
