﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Filmoon.WebAPI.Migrations
{
    [DbContext(typeof(FilmoonContext))]
    partial class FilmoonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
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

            modelBuilder.Entity("Filmoon.Entities.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PersonEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Filmoon.Entities.RentalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("RentalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Rentals");
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

            modelBuilder.Entity("Filmoon.Entities.DirectorEntity", b =>
                {
                    b.HasBaseType("Filmoon.Entities.PersonEntity");

                    b.HasDiscriminator().HasValue("DirectorEntity");
                });

            modelBuilder.Entity("Filmoon.Entities.ScreenwriterEntity", b =>
                {
                    b.HasBaseType("Filmoon.Entities.PersonEntity");

                    b.HasDiscriminator().HasValue("ScreenwriterEntity");
                });

            modelBuilder.Entity("Filmoon.Entities.UserEntity", b =>
                {
                    b.HasBaseType("Filmoon.Entities.PersonEntity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("UserEntity");
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
                    b.HasOne("Filmoon.Entities.MovieEntity", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("Filmoon.Entities.UserEntity", "User")
                        .WithMany("Rentals")
                        .HasForeignKey("UserId");

                    b.Navigation("Movie");

                    b.Navigation("User");
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

            modelBuilder.Entity("Filmoon.Entities.UserEntity", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
