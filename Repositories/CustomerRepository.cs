using System.Collections.Generic;
using System.Linq;

namespace Customers.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IList<Customer> GetAll()
        {
            using (var db = new CustomersEntities())
            {
                return db.Customers.ToList();
            }
        }

        public Customer GetById(int id)
        {
            using (var db = new CustomersEntities())
            {
                return db.Customers.FirstOrDefault(c => c.Id.Equals(id));
            }
        }

        public void Save(Customer customer)
        {
            if (customer.Id.Equals(0))
            {
                Add(customer);
                return;
            }

            Update(customer);
        }

        public void Delete(int id)
        {
            using (var db = new CustomersEntities())
            {
                var cust = db.Customers.Single(c => c.Id.Equals(id)); ;
                db.Customers.Remove(cust);
                db.SaveChanges();
            }
        }

        private void Add(Customer customer)
        {
            var newCust = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            };

            using (var db = new CustomersEntities())
            {
                db.Customers.Add(newCust);
                db.SaveChanges();                
            }
        }

        private void Update(Customer customer)
        {
            using (var db = new CustomersEntities())
            {
                var cust = db.Customers.Single(c => c.Id.Equals(customer.Id));

                cust.Name = customer.Name;
                cust.Email = customer.Email;
                cust.Phone = customer.Phone;

                db.SaveChanges();
            }
        }
    }
}