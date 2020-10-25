using StudentData.Domain.Core;
using StudentData.Services.Interfaces.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Services.Interfaces
{
    public interface IGroupsServices
    {
        Task<PagedViewModel<GroupView>> GetGroups(string name, int pageNumber, int pageSize);
        void Create(Group group);
        void Update(Group group);
        void Delete(Int64 id);
    }
}
