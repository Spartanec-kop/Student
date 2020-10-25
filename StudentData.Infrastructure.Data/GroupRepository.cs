using Microsoft.EntityFrameworkCore;
using StudentData.Domain.Core;
using StudentData.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StudentData.Infrastructure.Data
{
    public class GroupRepository : IRepository<Group>
    {
        private StudentContext db;
        private bool disposed = false;

        public GroupRepository()
        {
            this.db = new StudentContext();
        }

        public IEnumerable<Group> GetAll()
        {
            return db.Groups.ToList();
        }

        public Group GetId(int id)
        {
            return db.Groups.Find(id);
        }

        public IEnumerable<Group> Find(Expression<Func<Group, bool>> predicate)
        {
            IQueryable<Group> query = db.Groups.Where(predicate);
            return query.ToList();
        }

        public void Create(Group item)
        {
            db.Groups.Add(item);
        }

        public void Update(Group item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Group group = db.Groups.Find(id);
            if (group != null)
            {
                db.Groups.Remove(group);
            }
        }

        public void Save()
        {
            db.SaveChanges();
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
