﻿// <auto-generated />
using System;
using AuditService.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuditService.Migrations
{
    [DbContext(typeof(AuditDbContext))]
    [Migration("20240304161150_TestMigrationUserFileCollections")]
    partial class TestMigrationUserFileCollections
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("AuditService.Entities.Entities.AuditEvents.AuditEventBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TrackedFileId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TrackedUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("event_type")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TrackedFileId");

                    b.HasIndex("TrackedUserId");

                    b.ToTable("AuditEvents");

                    b.HasDiscriminator<string>("event_type").HasValue("AuditEventBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AuditService.Entities.Entities.TrackedFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TrackedFiles");
                });

            modelBuilder.Entity("AuditService.Entities.Entities.TrackedUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TrackedUsers");
                });

            modelBuilder.Entity("AuditService.Entities.Entities.AuditEvents.FileCreatedAuditEvent", b =>
                {
                    b.HasBaseType("AuditService.Entities.Entities.AuditEvents.AuditEventBase");

                    b.HasDiscriminator().HasValue("file_created");
                });

            modelBuilder.Entity("AuditService.Entities.Entities.AuditEvents.AuditEventBase", b =>
                {
                    b.HasOne("AuditService.Entities.Entities.TrackedFile", "TrackedFile")
                        .WithMany("AuditEvents")
                        .HasForeignKey("TrackedFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuditService.Entities.Entities.TrackedUser", "TrackedUser")
                        .WithMany("AuditEvents")
                        .HasForeignKey("TrackedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrackedFile");

                    b.Navigation("TrackedUser");
                });

            modelBuilder.Entity("AuditService.Entities.Entities.TrackedFile", b =>
                {
                    b.Navigation("AuditEvents");
                });

            modelBuilder.Entity("AuditService.Entities.Entities.TrackedUser", b =>
                {
                    b.Navigation("AuditEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
