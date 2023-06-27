
namespace EasyCash.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(Guid id);
        List<T> GetList();
    }
}
