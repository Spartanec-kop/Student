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
    public class StudentRepository : IRepository<Student>
    {
        private readonly StudentContext db;
        private bool disposed = false;

        public StudentRepository (StudentContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await db.Students.Include(c => c.StudentGroups).ThenInclude(sc => sc.Group).ToListAsync();
        }

        public async Task<Student> GetId(Int64 id)
        {
            return await db.Students.Include(c => c.StudentGroups).ThenInclude(sc => sc.Group).FirstOrDefaultAsync(s => s.Id == id);
        }

        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            IQueryable<Student> query = db.Students.Include(c => c.StudentGroups).ThenInclude(sc => sc.Group).Where(predicate);
            return query;
        }
        public async Task<int> recordCount(Expression<Func<Student, bool>> predicate)
        {
            IQueryable<Student> query = db.Students.Include(c => c.StudentGroups).ThenInclude(sc => sc.Group).Where(predicate);
            return await query.CountAsync();
        }

        public async void Create(Student item)
        {
            await db.Students.AddAsync(item);
        }

        public void Update(Student item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async void Delete(Int64 id)
        {
            Student student = await db.Students.FindAsync(id);
            if (student != null)
            {
                db.Students.Remove(student);
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
