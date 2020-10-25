using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Domain.Interfaces
{
    public interface IStudentGroupRepository : IDisposable
    {
        void AddStudentToGroup(Int64 studentId, Int64 groupId);
        void RemoveStudentfromGroup(Int64 studentId, Int64 groupId);
        void Save();
    }
}
