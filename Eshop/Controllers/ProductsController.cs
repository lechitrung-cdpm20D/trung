using Eshop.Data;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class ProductsController : Controller
    {
        private EshopContext _context;
        public ProductsController (EshopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Details (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var products = _context.Products.FirstOrDefault(x => x.Id == id);
            if(products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        public IActionResult Delete (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Name,SKU,Description,Price,Image")] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int? id, [Bind("Id,Name,SKU,Description,Image,Price")] Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
