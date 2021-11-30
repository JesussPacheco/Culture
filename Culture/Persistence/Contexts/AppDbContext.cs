using Culture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Culture.Extensions;

namespace Culture.Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<Destination>Destinations { get; set; }
        public DbSet<Hotel>Hotels { get; set; }
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Constrains Destination
            
            base.OnModelCreating(builder);
            builder.Entity<Destination>().ToTable("Destinations");
            builder.Entity<Destination>().HasKey(p => p.Id);
            builder.Entity<Destination>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Destination>().Property(p => p.Name).IsRequired();
            builder.Entity<Destination>().Property(p => p.City).IsRequired();
            builder.Entity<Destination>().Property(p => p.Country).IsRequired();
            builder.Entity<Destination>().Property(p => p.PhotoUrl);
            
            //Relation with Hotels

            builder.Entity<Destination>()
                .HasMany(p => p.Hotels)
                .WithOne(p => p.Destination)
                .HasForeignKey(p => p.DestinationId);
            
            //Mock Data
            builder.Entity<Destination>().HasData(
                new Destination
                {
                    Id = 1,
                    Name = "Torre Eiffel",
                    City = "Paris",
                    Country = "France",
                    PhotoUrl =
                        "https://images.chicmagazine.com.mx/YaunwslDzprh_vg7kiIQ"
                },
                new Destination
                {
                    Id = 2,
                    Name = "Etiham Stadiu,",
                    City = "Manchester",
                    Country = "Uk",
                    PhotoUrl =
                        "https://www.mancity.com/meta"
                }
            );
            //Constrains Hotels
            builder.Entity<Hotel>().ToTable("Hotels");
            builder.Entity<Hotel>().HasKey(p => p.Id);
            builder.Entity<Hotel>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Hotel>().Property(p => p.Name).IsRequired();
            builder.Entity<Hotel>().Property(p => p.Address).IsRequired();
            builder.Entity<Hotel>().Property(p => p.PhotoUrl);
            builder.Entity<Hotel>().Property(p => p.Altitude).IsRequired();
            builder.Entity<Hotel>().Property(p => p.Latitude).IsRequired();
            builder.Entity<Hotel>().Property(p => p.Longitude).IsRequired();
            builder.UseSnakeCaseNamingConventions();

        }
        
     
        
        
        
    }
}