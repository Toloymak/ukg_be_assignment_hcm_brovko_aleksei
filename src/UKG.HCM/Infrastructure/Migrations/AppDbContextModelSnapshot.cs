﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UKG.HCM.Infrastructure.Contexts;

#nullable disable

namespace UKG.HCM.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccountDalRoleDal", b =>
                {
                    b.Property<Guid>("AccountDalAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RolesName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AccountDalAccountId", "RolesName");

                    b.HasIndex("RolesName");

                    b.ToTable("AccountRoles", (string)null);
                });

            modelBuilder.Entity("UKG.HCM.Infrastructure.Entities.AccountDal", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccountId");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("UKG.HCM.Infrastructure.Entities.ActionActorDal", b =>
                {
                    b.Property<Guid>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Service")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ActorId");

                    b.HasIndex("PersonId");

                    b.ToTable("ActionActors", (string)null);

                    b.HasData(
                        new
                        {
                            ActorId = new Guid("4ecc4d06-11b8-4e82-9dd6-c93eff741a38"),
                            Service = "Anonymous"
                        });
                });

            modelBuilder.Entity("UKG.HCM.Infrastructure.Entities.PersonDal", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedByActorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PersonId");

                    b.HasIndex("CreatedByActorId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("People", (string)null);
                });

            modelBuilder.Entity("UKG.HCM.Infrastructure.Entities.RoleDal", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Name");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Name = "HR ADMIN"
                        },
                        new
                        {
                            Name = "MANAGER"
                        },
                        new
                        {
                            Name = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("AccountDalRoleDal", b =>
                {
                    b.HasOne("UKG.HCM.Infrastructure.Entities.AccountDal", null)
                        .WithMany()
                        .HasForeignKey("AccountDalAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UKG.HCM.Infrastructure.Entities.RoleDal", null)
                        .WithMany()
                        .HasForeignKey("RolesName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UKG.HCM.Infrastructure.Entities.AccountDal", b =>
                {
                    b.HasOne("UKG.HCM.Infrastructure.Entities.PersonDal", "Person")
                        .WithOne("Account")
                        .HasForeignKey("UKG.HCM.Infrastructure.Entities.AccountDal", "PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("UKG.HCM.Infrastructure.Entities.ActionActorDal", b =>
                {
                    b.HasOne("UKG.HCM.Infrastructure.Entities.PersonDal", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Person");
                });

            modelBuilder.Entity("UKG.HCM.Infrastructure.Entities.PersonDal", b =>
                {
                    b.HasOne("UKG.HCM.Infrastructure.Entities.ActionActorDal", "CreatedByActor")
                        .WithMany()
                        .HasForeignKey("CreatedByActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByActor");
                });

            modelBuilder.Entity("UKG.HCM.Infrastructure.Entities.PersonDal", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
