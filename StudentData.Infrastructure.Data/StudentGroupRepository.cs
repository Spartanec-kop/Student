using StudentData.Domain.Core;
using StudentData.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentData.Infrastructure.Data
{
    public class StudentGroupRepository : IStudentGroupRepository
    {
        private readonly StudentContext db;
        private bool disposed = false;
        public StudentGroupRepository(StudentContext context)
        {
            this.db = context;
        }
        public void AddStudentToGroup(long studentId, long groupId)
        {
            Group group = db.Groups.Find(groupId);
            if (group != null)
            {
                group.StudentGroups.Add(new StudentGroup { GroupId = groupId, StudentId = studentId });
            }
        }

        public void RemoveStudentfromGroup(long studentId, long groupId)
        {
            Student student = db.Students.Find(studentId);
            if (student != null)
            {
                var studentGroup = student.StudentGroups.FirstOrDefault(g => g.GroupId == groupId);
                student.StudentGroups.Remove(studentGroup);
            }
        }

        public async void Save()
        {
            await db.SaveChangesAsync();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
