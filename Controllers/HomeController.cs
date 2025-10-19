using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(LeadFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Veritaban�na kaydet
                _context.Leads.Add(model);
                _context.SaveChanges();

                TempData["Success"] = "Bilgileriniz al�nd�, te�ekk�rler!";
                return RedirectToAction("Index");
            }

            return View("Index", model);
        }
    }
}
