using System.Collections.Generic;

namespace Customers.Repositories
{
    public interface ICustomerRepository
    {
        void Delete(int id);
        IList<Customer> GetAll();
        Customer GetById(int id);
        void Save(Customer customer);
    }
}