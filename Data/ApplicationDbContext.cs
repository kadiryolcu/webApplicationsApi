using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeadFormModel> Leads { get; set; }
    }
}
