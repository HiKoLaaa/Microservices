﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProfileService.Database;

namespace ProfileService.Migrations
{
    [DbContext(typeof(ProfileDbContext))]
    partial class ProfileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("ProfileService.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_departments");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("ProfileService.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer")
                        .HasColumnName("department_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("last_name");

                    b.HasKey("Id")
                        .HasName("pk_profiles");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_profiles_department_id");

                    b.ToTable("profiles");
                });

            modelBuilder.Entity("ProfileService.Models.Profile", b =>
                {
                    b.HasOne("ProfileService.Models.Department", "Department")
                        .WithMany("Profiles")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("fk_profiles_departments_department_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ProfileService.Models.Department", b =>
                {
                    b.Navigation("Profiles");
                });
#pragma warning restore 612, 618
        }
    }
}
