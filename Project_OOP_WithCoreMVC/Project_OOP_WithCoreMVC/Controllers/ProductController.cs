using Microsoft.AspNetCore.Mvc;
using Project_OOP_WithCoreMVC.Entity;
using Project_OOP_WithCoreMVC.ProjeContext;

namespace Project_OOP_WithCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.products.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            context.Add(p);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(int id) 
        {
            var value =context.products.Where(x=>x.ID == id).FirstOrDefault();
            context.products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = context.products.Where(x => x.ID == id).FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            var value = context.products.Where(x => x.ID == p.ID).FirstOrDefault();
            value.Name= p.Name;
            value.ID = p.ID;
            value.Price= p.Price;
            value.Stock= p.Stock;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
