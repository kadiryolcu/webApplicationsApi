using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Örnek: api/values?fullName=Ali veya api/values?email=ali@example.com
        [HttpGet]
        public IActionResult GetLeads([FromQuery] LeadFormQuery query)
        {
            var leads = _context.Leads.AsQueryable();

            // sadece dolu olan alanlara göre filtre uygula
            if (!string.IsNullOrWhiteSpace(query.FullName))
                leads = leads.Where(l => l.FullName.ToLower().Contains(query.FullName.ToLower()));

            if (!string.IsNullOrWhiteSpace(query.Email))
                leads = leads.Where(l => l.Email.ToLower().Contains(query.Email.ToLower()));

            if (!string.IsNullOrWhiteSpace(query.Goal))
                leads = leads.Where(l => l.Goal.ToLower().Contains(query.Goal.ToLower()));

            if (!string.IsNullOrWhiteSpace(query.Company))
                leads = leads.Where(l => l.Company.ToLower().Contains(query.Company.ToLower()));

            if (!string.IsNullOrWhiteSpace(query.Industry))
                leads = leads.Where(l => l.Industry.ToLower().Contains(query.Industry.ToLower()));

            // hiçbir filtre girilmemişse boş liste dönmesin, tüm veriyi dön
            // (bunu istersen kaldırabiliriz)
            var result = leads.Any() ? leads.ToList() : _context.Leads.ToList();

            return Ok(result);
        }
    }
}
