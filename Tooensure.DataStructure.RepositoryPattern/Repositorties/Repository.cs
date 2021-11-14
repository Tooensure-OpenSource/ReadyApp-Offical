using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual TEntity? FindById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual ServiceResponse<string> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

            return
                new(
                    Data: string.Empty,
                    Successful: _context.SaveChanges() == 0,
                    Message: $"[ ]");
        }
        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

    }
}
