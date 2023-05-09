using CDSiteUsers.Models;
using Microsoft.EntityFrameworkCore;

namespace CDSiteUsers.Data
{
    public class StoreAPIDbContext : DbContext
    {
        public StoreAPIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CDModel> CDs { get; set; }

        public DbSet<UserModel> Users { get; set; }
    }
}
