﻿// <auto-generated />
using System;
using Api_One_Trick_Pony_Br.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_One_Trick_Pony_Br.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api_One_Trick_Pony_Br.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PonyId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PonyId");

                    b.ToTable("Account");

                    b.HasDiscriminator().HasValue("Account");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Api_One_Trick_Pony_Br.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<int?>("PonyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PonyId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Api_One_Trick_Pony_Br.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("Api_One_Trick_Pony_Br.Models.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlatformId")
                        .HasColumnType("integer");

                    b.Property<int?>("PonyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.HasIndex("PonyId");

                    b.ToTable("SocialMedia");
                });

            modelBuilder.Entity("Api_One_Trick_Pony_Br.Models.Pony", b =>
                {
                    b.HasBaseType("Api_One_Trick_Pony_Br.Models.Account");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Champion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IconId")
                        .HasColumnType("integer");

                    b.Property<int>("Karma")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Pony");
                });

            modelBuilder.Entity("Api_One_Trick_Pony_Br.Models.Account", b =>
                {
                    b.HasOne("Api_One_Trick_Pony_Br.Models.Pony", null)
                        .WithMany("Accounts")
                        .HasForeignKey("PonyId");
                });

            modelBuilder.Entity("Api_One_Trick_Pony_Br.Models.Comment", b =>
                {
                    b.HasOne("Api_One_Trick_Pony_Br.Models.Account", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Api_One_Trick_Pony_Br.Models.Pony", null)
                        .WithMany("Comments")
                        .HasForeignKey("PonyId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Api_One_Trick_Pony_Br.Models.SocialMedia", b =>
                {
                    b.HasOne("Api_One_Trick_Pony_Br.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_One_Trick_Pony_Br.Models.Pony", null)
                        .WithMany("SocialMedias")
                        .HasForeignKey("PonyId");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("Api_One_Trick_Pony_Br.Models.Pony", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Comments");

                    b.Navigation("SocialMedias");
                });
#pragma warning restore 612, 618
        }
    }
}
