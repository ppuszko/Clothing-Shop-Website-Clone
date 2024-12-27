using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NikeClone.Application.Interfaces;
using NikeClone.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Infrastructure.Repository {
    public class Repository<T> : IRepository<T>  where T : class{
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db) {
            _db = db;
            dbSet = _db.Set<T>();
            
        }
        public void Add(T entity) {
            dbSet.Add(entity);
        }

        public bool Any(Expression<Func<T, bool>> filter) {
            return dbSet.Any(filter);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null) {
            IQueryable<T> query = dbSet;
            if(filter is not null) {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties)) {
                foreach(var prop in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) {
                    query = query.Include(prop);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null) {
            IQueryable<T> query = dbSet;
            if (filter is not null) {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties)) {
                foreach(var prop in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) {
                    query = query.Include(prop);
                }
            }
            return query.ToList();
        }

        public void Remove(object entity) {
            if (entity is T) {
                dbSet.Remove((T)entity);
            } 
            else if (entity is List<T>) {
                dbSet.RemoveRange((List<T>)entity);
            }
        }
    }
}
