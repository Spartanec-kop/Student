using Microsoft.EntityFrameworkCore;
using StudentData.Domain.Core;
using StudentData.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Infrastructure.Data
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly StudentContext db;
        private bool disposed = false;

        public GroupRepository(StudentContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await db.Groups.Include(c => c.StudentGroups).ThenInclude(sc => sc.Student).ToListAsync();
        }

        public async Task<Group> GetId(Int64 id)
        {
            return await db.Groups.Include(c => c.StudentGroups).ThenInclude(sc => sc.Student).FirstOrDefaultAsync(s => s.Id == id);
        }

        public IEnumerable<Group> Find(Expression<Func<Group, bool>> predicate)
        {
            IQueryable<Group> query = db.Groups.Where(predicate);
            return query.ToList();
        }

        public async Task<int> recordCount(Expression<Func<Group, bool>> predicate)
        {
            IQueryable<Group> query = db.Groups.Where(predicate);
            return await query.CountAsync();
        }


        public void Create(Group item)
        {
            db.Groups.Add(item);
        }

        public void Update(Group item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Int64 id)
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
