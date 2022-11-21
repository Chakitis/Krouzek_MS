using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Krouzek_MS.Models;

namespace Krouzek_MS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Krouzek_MS.Models.Article> Article { get; set; }
        public DbSet<Krouzek_MS.Models.AktualityLes> AktualityLes { get; set; }
    }
}