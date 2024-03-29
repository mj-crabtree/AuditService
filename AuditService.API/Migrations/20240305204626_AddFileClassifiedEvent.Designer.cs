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
    [Migration("20240305204626_AddFileClassifiedEvent")]
    partial class AddFileClassifiedEvent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("AuditService.Entities.Entities.AuditEvents.AuditEvent", b =>
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

                    b.HasDiscriminator<string>("event_type").HasValue("AuditEvent");

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

            modelBuilder.Entity("AuditService.Entities.Entities.AuditEvents.FileClassifiedAuditEvent", b =>
                {
                    b.HasBaseType("AuditService.Entities.Entities.AuditEvents.AuditEvent");

                    b.Property<string>("CurrentClassification")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NewClassificationTier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OldClassificationTier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("SuccessfulClassification")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("file_classified");
                });

            modelBuilder.Entity("AuditService.Entities.Entities.AuditEvents.FileCreatedAuditEvent", b =>
                {
                    b.HasBaseType("AuditService.Entities.Entities.AuditEvents.AuditEvent");

                    b.HasDiscriminator().HasValue("file_created");
                });

            modelBuilder.Entity("AuditService.Entities.Entities.AuditEvents.FileSharedAuditEvent", b =>
                {
                    b.HasBaseType("AuditService.Entities.Entities.AuditEvents.AuditEvent");

                    b.Property<Guid>("RecipientId")
                        .HasColumnType("TEXT");

                    b.HasIndex("RecipientId");

                    b.HasDiscriminator().HasValue("file_shared");
                });

            modelBuilder.Entity("AuditService.Entities.Entities.AuditEvents.AuditEvent", b =>
                {
                    b.HasOne("AuditService.Entities.Entities.TrackedFile", "TrackedFile")
                        .WithMany()
                        .HasForeignKey("TrackedFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuditService.Entities.Entities.TrackedUser", "TrackedUser")
                        .WithMany()
                        .HasForeignKey("TrackedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrackedFile");

                    b.Navigation("TrackedUser");
                });

            modelBuilder.Entity("AuditService.Entities.Entities.AuditEvents.FileSharedAuditEvent", b =>
                {
                    b.HasOne("AuditService.Entities.Entities.TrackedUser", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipient");
                });
#pragma warning restore 612, 618
        }
    }
}
