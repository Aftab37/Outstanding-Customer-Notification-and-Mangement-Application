// Controllers/CustomerController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers.ToListAsync();

           
            var notificationCount = customers.Count(c => c.Status != "Paid" && c.DueDate < DateTime.Now);

            ViewData["NotificationCount"] = notificationCount;

            return View(customers);


        }

        public async Task<IActionResult> MarkAsPaid(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                customer.Status = "Paid";
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        
    }
}
