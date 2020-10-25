using StudentData.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Services.Interfaces
{
    public interface IGroupsServices
    {
        IEnumerable<Group> GetGroups(string name, int firstItem, int pageCount);
        void Create(Group group);
        void Update(Group group);
        void Delete(Int64 id);
    }
}
