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

            modelBuilder.Entity<Code>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });

            modelBuilder.Entity<Code>(b =>
            {
                b.HasData(new
                {
                    Id = 1,
                    Description = "Description 1",
                    Name = "Code 1"
                });
                b.OwnsOne(e => e.Owner).HasData(new
                {
                    CodeId = 1,
                    Id = 1,
                    GIn = 9223372036854775804,
                    Name = "Owner 1",
                    Nit = 9223372036854775803
                });
            });

            modelBuilder.Entity<Code>(b =>
            {
                b.HasData(new
                {
                    Id = 2,
                    Description = "Description 2",
                    Name = "Code 2"
                });
                b.OwnsOne(e => e.Owner).HasData(new
                {
                    CodeId = 2,
                    Id = 2,
                    GIn = 9223372036854775806,
                    Name = "Owner 2",
                    Nit = 9223372036854775802
                });
            });

            modelBuilder.Entity<Code>(b =>
            {
                b.HasData(new
                {
                    Id = 3,
                    Description = "Description 3",
                    Name = "Code 3"
                });
                b.OwnsOne(e => e.Owner).HasData(new
                {
                    CodeId = 3,
                    Id = 3,
                    GIn = 9223372036854775802,
                    Name = "Owner 3",
                    Nit = 9223372036854775801
                });
            });

            modelBuilder.Entity<Code>(b =>
            {
                b.HasData(new
                {
                    Id = 4,
                    Description = "Description 4",
                    Name = "Code 4"
                });
                b.OwnsOne(e => e.Owner).HasData(new
                {
                    CodeId = 4,
                    Id = 1,
                    GIn = 9223372036854775804,
                    Name = "Owner 1",
                    Nit = 9223372036854775803
                });
            });

        }
    }
}