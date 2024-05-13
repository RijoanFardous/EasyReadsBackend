﻿// <auto-generated />
using System;
using EasyReadsDAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyReadsDAL.Migrations
{
    [DbContext(typeof(EasyReadsContext))]
    [Migration("20240509145916_ArticlesAdded")]
    partial class ArticlesAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EasyReadsDAL.EF.Entities.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Audience")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("BookmarksCount")
                        .HasColumnType("int");

                    b.Property<int>("CommentsCount")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("CoverImage")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("LikesCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NumberOfWords")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("WrittenBy")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("ArticleId");

                    b.HasIndex("WrittenBy");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("EasyReadsDAL.EF.Entities.ArticleVersion", b =>
                {
                    b.Property<int>("VersionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NumberOfWords")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("VersionId");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleVersions");
                });

            modelBuilder.Entity("EasyReadsDAL.EF.Entities.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Bio")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("FollowersCount")
                        .HasColumnType("int");

                    b.Property<int>("FollowingCount")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePicture")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Website")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ProfileId");

                    b.HasIndex("Username");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("EasyReadsDAL.EF.Entities.Token", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TokenKey")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("TokenId");

                    b.HasIndex("Username");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("EasyReadsDAL.EF.Entities.User", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateOnly>("JoinDate")
                        .HasColumnType("date");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EasyReadsDAL.EF.Entities.Article", b =>
                {
                    b.HasOne("EasyReadsDAL.EF.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("WrittenBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("EasyReadsDAL.EF.Entities.ArticleVersion", b =>
                {
                    b.HasOne("EasyReadsDAL.EF.Entities.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("EasyReadsDAL.EF.Entities.Profile", b =>
                {
                    b.HasOne("EasyReadsDAL.EF.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyReadsDAL.EF.Entities.Token", b =>
                {
                    b.HasOne("EasyReadsDAL.EF.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
