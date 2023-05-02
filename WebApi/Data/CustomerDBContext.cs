using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebApi.Entity;

namespace WebApi.Data
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)

        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
