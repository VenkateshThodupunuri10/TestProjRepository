using Microsoft.EntityFrameworkCore;
using POCWebAPI.Models;

namespace POCWebAPI.DBConnectionLayer
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<FBResult> FBResults { get; set; }

    }
}
