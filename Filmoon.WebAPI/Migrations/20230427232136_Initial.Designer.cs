﻿// <auto-generated />
using System;
using Filmoon.WebAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Filmoon.WebAPI.Migrations
{
    [DbContext(typeof(FilmoonContext))]
    [Migration("20230427232136_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DirectorEntityMovieEntity", b =>
                {
                    b.Property<int>("DirectorsId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("DirectorsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("DirectorEntityMovieEntity");
                });

            modelBuilder.Entity("Filmoon.Entities.DirectorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Filmoon.Entities.GenreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MovieEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieEntityId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Filmoon.Entities.MovieEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LengthInMinutes")
                        .HasColumnType("int");

                    b.Property<byte[]>("Poster")
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Filmoon.Entities.RentalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MovieId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Filmoon.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Filmoon.Entities.ScreenwriterEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Screenwriters");
                });

            modelBuilder.Entity("Filmoon.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MovieEntityScreenwriterEntity", b =>
                {
                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.Property<int>("ScreenwritersId")
                        .HasColumnType("int");

                    b.HasKey("MoviesId", "ScreenwritersId");

                    b.HasIndex("ScreenwritersId");

                    b.ToTable("MovieEntityScreenwriterEntity");
                });

            modelBuilder.Entity("Filmoon.Entities.AdministratorEntity", b =>
                {
                    b.HasBaseType("Filmoon.Entities.UserEntity");

                    b.HasDiscriminator().HasValue("AdministratorEntity");
                });

            modelBuilder.Entity("Filmoon.Entities.CustomerEntity", b =>
                {
                    b.HasBaseType("Filmoon.Entities.UserEntity");

                    b.HasDiscriminator().HasValue("CustomerEntity");
                });

            modelBuilder.Entity("DirectorEntityMovieEntity", b =>
                {
                    b.HasOne("Filmoon.Entities.DirectorEntity", null)
                        .WithMany()
                        .HasForeignKey("DirectorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Filmoon.Entities.MovieEntity", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Filmoon.Entities.GenreEntity", b =>
                {
                    b.HasOne("Filmoon.Entities.MovieEntity", null)
                        .WithMany("Genres")
                        .HasForeignKey("MovieEntityId");
                });

            modelBuilder.Entity("Filmoon.Entities.RentalEntity", b =>
                {
                    b.HasOne("Filmoon.Entities.CustomerEntity", "Customer")
                        .WithMany("Rentals")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Filmoon.Entities.MovieEntity", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.Navigation("Customer");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Filmoon.Entities.UserEntity", b =>
                {
                    b.HasOne("Filmoon.Entities.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MovieEntityScreenwriterEntity", b =>
                {
                    b.HasOne("Filmoon.Entities.MovieEntity", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Filmoon.Entities.ScreenwriterEntity", null)
                        .WithMany()
                        .HasForeignKey("ScreenwritersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Filmoon.Entities.MovieEntity", b =>
                {
                    b.Navigation("Genres");
                });

            modelBuilder.Entity("Filmoon.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
