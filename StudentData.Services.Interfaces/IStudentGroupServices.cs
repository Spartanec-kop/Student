using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Services.Interfaces
{
    public interface IStudentGroupServices
    {
        void AddStudentToGroup(Int64 studentId, Int64 groupId);
        void RemoveStudentfromGroup(Int64 studentId, Int64 groupId);
    }
}
