﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PostgresEFCore.Data;

namespace PostgresEFCore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200708002342_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PostgresEFCore.Models.Code", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Codes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description 1",
                            Name = "Name 2"
                        });
                });

            modelBuilder.Entity("PostgresEFCore.Models.Code", b =>
                {
                    b.OwnsOne("PostgresEFCore.Models.Enterprise", "Owner", b1 =>
                        {
                            b1.Property<int>("CodeId")
                                .HasColumnType("integer");

                            b1.Property<long>("GIn")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .HasColumnType("integer");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<long>("Nit")
                                .HasColumnType("bigint");

                            b1.HasKey("CodeId");

                            b1.ToTable("Enterprises");

                            b1.WithOwner()
                                .HasForeignKey("CodeId");

                            b1.HasData(
                                new
                                {
                                    CodeId = 1,
                                    GIn = 9223372036854775807L,
                                    Id = 1,
                                    Name = "Name 1",
                                    Nit = 9223372036854775807L
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
