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
    public class StudentRepository : IRepository<Student>
    {
        private StudentContext db;
        private bool disposed = false;

        public StudentRepository ()
        {
            this.db = new StudentContext();
        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public Student GetId(int id)
        {
            return db.Students.Find(id);
        }

        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            IQueryable<Student> query = db.Students.Where(predicate);
            return query.ToList();
        }

        public void Create(Student item)
        {
            db.Students.Add(item);
        }

        public void Update(Student item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Student student = db.Students.Find(id);
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
