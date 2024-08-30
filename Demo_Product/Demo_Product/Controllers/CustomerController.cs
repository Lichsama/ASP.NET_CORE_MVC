using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        JobManager customerManage = new JobManager(new EfJobDal());

        public IActionResult Index()
        {
            var values = customerManager.GetCustomersListWithJob();
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
            
            List<SelectListItem> values = (from x in customerManage.TGetList() select new SelectListItem
            {
                Text=x.Name,
                Value=x.JobId.ToString()
            }).ToList();
            ViewBag.v=values;
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if (validationResult.IsValid)
            {
                customerManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        
        
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            List<SelectListItem> values = (from x in customerManage.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.JobId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = customerManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            customerManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
