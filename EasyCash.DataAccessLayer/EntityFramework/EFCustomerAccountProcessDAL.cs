
using EasyCash.DataAccessLayer.Abstract;
using EasyCash.DataAccessLayer.Repositories;
using EasyCash.EntityLayer.Concrete;

namespace EasyCash.DataAccessLayer.EntityFramework
{
    public class EFCustomerAccountProcessDAL : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
    }
}
