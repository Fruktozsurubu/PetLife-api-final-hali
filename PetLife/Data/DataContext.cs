using Microsoft.EntityFrameworkCore;
using Models.Pet;
using Models.User;
using System.Drawing;

namespace PetLife.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer("Server=TARDIS;Database=PetLife2;User Id=sa;Password=1;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Pet> Pets => Set<Pet>();
    }
}
