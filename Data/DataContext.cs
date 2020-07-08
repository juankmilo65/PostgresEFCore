using PostgresEFCore.Models;
using Microsoft.EntityFrameworkCore;


namespace PostgresEFCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Code> Codes { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var code = new
            {
                Id = 1,
                Description = "Description 1",
                Name = "Name 2"
                //OwnerId = 1,
            };

            var enterprise = new 
            {
                CodeId =1,
                Id = 1,
                GIn = 9223372036854775807,
                Name = "Name 1",
                Nit = 9223372036854775807
                // OwnerId = 1
            };

            modelBuilder.Entity<Code>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });

            // modelBuilder.Entity<Enterprise>().HasData(enterprise);
            //modelBuilder.Entity<Code>().HasData(code)//.HasKey(x=> new {  OwnerId = x.Id  }).HasName("Id");

            modelBuilder.Entity<Code>(b=> {
                b.HasData(code);
                b.OwnsOne(e => e.Owner).HasData(enterprise);
            });
        }
    }
}