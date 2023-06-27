using EasyCash.DataAccessLayer.Abstract;
using EasyCash.DataAccessLayer.Concrete;

namespace EasyCash.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using var ctx = new Context();
            ctx.Set<T>().Remove(entity);
            ctx.SaveChanges();
        }

        public T GetById(Guid id)
        {
            using var ctx = new Context();
            return ctx.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var ctx = new Context();
            return ctx.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            using var ctx = new Context();
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Update(T entity)
        {
            using var ctx = new Context();
            ctx.Set<T>().Update(entity);
            ctx.SaveChanges();
        }
    }
}
