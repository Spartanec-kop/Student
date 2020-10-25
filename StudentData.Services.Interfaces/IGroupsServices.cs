using StudentData.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Services.Interfaces
{
    public interface IGroupsServices
    {
        IEnumerable<Group> GetStudents(string name, int firstItem, int pageCount);
    }
}
