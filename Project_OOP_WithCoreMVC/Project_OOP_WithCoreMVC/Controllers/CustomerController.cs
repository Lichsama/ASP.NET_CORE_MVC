using Microsoft.AspNetCore.Mvc;
using Project_OOP_WithCoreMVC.Entity;
using Project_OOP_WithCoreMVC.ProjeContext;

namespace Project_OOP_WithCoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.customers.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            if(p.Name.Length>=6 && p.City!="" && p.City.Length>=3)
            {
                context.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.message = "Hatalı Kullanım";
                return View();
            }
        }
        public IActionResult DeleteCustomer(int id)
        {
            var value = context.customers.Where(x=>x.ID == id).FirstOrDefault();
            context.customers.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = context.customers.Where(context=>context.ID == id).FirstOrDefault();

            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            var value = context.customers.Where(x=>x.ID==p.ID).FirstOrDefault();
            value.Name= p.Name; 
            
            value.City= p.City;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
