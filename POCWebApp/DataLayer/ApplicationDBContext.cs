using Microsoft.EntityFrameworkCore;
using POCWebApp.Models;

namespace POCWebApp.DataLayer
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { 
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<FBResult> FBResults { get; set; }

    }
}
