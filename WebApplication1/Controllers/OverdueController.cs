using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Softcon_working_Draft_2.Controllers
{
    public class OverdueController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OverdueController(ApplicationDbContext context)
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
                TempData["message"] = "Customer has been Marked as Paid Succesfully";
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
