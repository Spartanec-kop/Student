using StudentData.Domain.Interfaces;
using StudentData.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Infrastructure.Business
{
    public class StudentGroupServices : IStudentGroupServices
    {
        IStudentGroupRepository studentGroupRepository;
        public StudentGroupServices(IStudentGroupRepository studentGroup)
        {
            studentGroupRepository = studentGroup;
        }
        public void AddStudentToGroup(long studentId, IEnumerable<long> groupsId)
        {
            foreach(var id in groupsId)
            {
                studentGroupRepository.AddStudentToGroup(studentId, id);
            }           
            studentGroupRepository.Save();
        }

        public void RemoveStudentfromGroup(long studentId, long groupId)
        {
            studentGroupRepository.RemoveStudentfromGroup(studentId, groupId);
            studentGroupRepository.Save();
        }
    }
}
