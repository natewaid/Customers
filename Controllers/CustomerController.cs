using System.Web.Mvc;
using Customers.Repositories;

namespace Customers.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository repository;

        public CustomerController()
        {
            repository = new CustomerRepository();
        }

        [Route("", Name = "customers.index")]
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        [Route("details/{id:int?}", Name = "customer.details")]
        public ActionResult Details(int? id = null)
        {
            if (!id.HasValue)
            {
                return View(new Customer());
            }

            var customer = repository.GetById(id.Value);

            return View(customer);
        }

        [HttpPost]
        [Route("details")]
        public ActionResult Details(Customer customer)
        {
            repository.Save(customer);

            return RedirectToAction("Index");
        }

        [Route("delete", Name = "customer.delete")]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}