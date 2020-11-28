﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Questioner.Repository.Classes.Entities;

namespace Questioner.Repository.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId", "AnswerText")
                        .IsUnique()
                        .HasDatabaseName("UX_Answer_AnswerText");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AnswerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PageLink")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("TopicId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TopicId", "QuestionText")
                        .IsUnique()
                        .HasDatabaseName("UX_Question_QuestionText");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("UX_Theme_Name");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<byte>("Percentage")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("ThemeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ThemeId", "Name")
                        .IsUnique()
                        .HasDatabaseName("UX_Topic_Name");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Answer", b =>
                {
                    b.HasOne("Questioner.Repository.Classes.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Link", b =>
                {
                    b.HasOne("Questioner.Repository.Classes.Entities.Answer", null)
                        .WithMany("Links")
                        .HasForeignKey("AnswerId");

                    b.HasOne("Questioner.Repository.Classes.Entities.Question", null)
                        .WithMany("Links")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Question", b =>
                {
                    b.HasOne("Questioner.Repository.Classes.Entities.Topic", "Topic")
                        .WithMany("Questions")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Topic", b =>
                {
                    b.HasOne("Questioner.Repository.Classes.Entities.Theme", "Theme")
                        .WithMany("Topics")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Answer", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Links");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Theme", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Questioner.Repository.Classes.Entities.Topic", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
