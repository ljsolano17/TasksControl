using Solution.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private SolutionDbContext dbContext = null;
        public Repository(SolutionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Delete(T entity)
        {
            try
            {
                dbContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return dbContext.Set<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetById(int id)
        {
            try
            {
                return dbContext.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(T entity)
        {
            try
            {
                if(dbContext.Entry<T>(entity).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                {
                    dbContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                else
                {
                    dbContext.Set<T>().Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T entity)
        {
            try
            {
                dbContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
