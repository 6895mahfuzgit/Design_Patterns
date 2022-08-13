using MediatRDemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatRDemoApp.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Contract> Contractss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Contract>()
                      .HasData(
                       new Contract {Id=1,FirstName="Mahfuz1",LastName="Shazol1" },
                       new Contract {Id=2,FirstName="Mahfuz2",LastName="Shazol2" },
                       new Contract {Id=3,FirstName="Mahfuz3",LastName="Shazol3" }
                      );
        }

    }
}
