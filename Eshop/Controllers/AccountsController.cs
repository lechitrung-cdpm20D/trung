using Eshop.Data;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Controllers
{
    public class AccountsController : Controller
    {
        private EshopContext _context;
        public AccountsController (EshopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var accounts=_context.Accounts.ToList();
            return View(accounts);
        }
        public IActionResult Details(int? id)
        {
            if(id== null)
            {
                return RedirectToAction("Index");
            }
            var accounts=_context.Accounts.FirstOrDefault(x=>x.Id==id);
            if (accounts == null)
            {
                return NotFound();
            }
            return View(accounts);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var account = _context.Accounts.FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Username,Password,Email,Phone,Address,FullName,Avatar")] Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var accounts = _context.Accounts.FirstOrDefault(x => x.Id == id);
            if (accounts == null)
            {
                return NotFound();
            }
            return View(accounts);
        }
        [HttpPost]
        public IActionResult Edit([Bind("Username,Password,Email,Phone,Address,FullName,Avatar")] Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
