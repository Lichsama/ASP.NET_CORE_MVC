using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        public IActionResult Index()
        {
            var values = customerManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteCustomer(int id)
        {
            var values = customerManager.TGetById(id);
            customerManager.TDelete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            customerManager.TInsert(p);
            return RedirectToAction("Index");
        }
    }
}
