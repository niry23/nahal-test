using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace NahalTest.Models
{
    public class EntrepriseContext : DbContext
    {
        public EntrepriseContext(DbContextOptions<EntrepriseContext> options) : base(options)
        {

        }
        public DbSet<Individuelle> Individuelles { get; set; }
        public DbSet<Societe> Societes { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entreprise>().ToTable("Entreprises");
        }
    }
}