﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentsEvents.Library.DBEntityModels
{
    public partial class StudentsEventsDataDbContext : DbContext
    {
        public StudentsEventsDataDbContext()
        {
        }

        public StudentsEventsDataDbContext(DbContextOptions<StudentsEventsDataDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<StudentGovernment> StudentGovernments { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VwEventGetAll> VwEventGetAlls { get; set; } = null!;
        public virtual DbSet<VwEventGetPublished> VwEventGetPublisheds { get; set; } = null!;
        public virtual DbSet<VwEventGetUnfinished> VwEventGetUnfinisheds { get; set; } = null!;
        public virtual DbSet<VwEventGetUnpublished> VwEventGetUnpublisheds { get; set; } = null!;
        public virtual DbSet<VwEventTag> VwEventTags { get; set; } = null!;
        public virtual DbSet<VwStudentGovernmentGetAll> VwStudentGovernmentGetAlls { get; set; } = null!;
        public virtual DbSet<VwTagGetAll> VwTagGetAlls { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Background).HasMaxLength(256);

                entity.Property(e => e.City)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('N/A')");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('N/A')");

                entity.Property(e => e.Language)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('N/A')");

                entity.Property(e => e.LastModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Latitude).HasDefaultValueSql("((0))");

                entity.Property(e => e.Location)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('N/A')");

                entity.Property(e => e.Longitude).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Organization)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('N/A')");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Region)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('N/A')");

                entity.Property(e => e.Thumbnail).HasMaxLength(256);

                entity.Property(e => e.Website)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('N/A')");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__Event__OwnerID__2BFE89A6");

                entity.HasOne(d => d.StudentGovernment)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.StudentGovernmentId)
                    .HasConstraintName("FK__Event__StudentGo__2B0A656D");

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Events)
                    .UsingEntity<Dictionary<string, object>>(
                        "EventTag",
                        l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__EventTags__TagId__2DE6D218"),
                        r => r.HasOne<Event>().WithMany().HasForeignKey("EventId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__EventTags__Event__2CF2ADDF"),
                        j =>
                        {
                            j.HasKey("EventId", "TagId").HasName("PK__EventTag__AF13078ACC144EDE");

                            j.ToTable("EventTags");
                        });
            });

            modelBuilder.Entity<StudentGovernment>(entity =>
            {
                entity.ToTable("StudentGovernment");

                entity.Property(e => e.City).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.Facebook)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('N/A')");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Region).HasMaxLength(128);

                entity.Property(e => e.ShortName).HasMaxLength(32);

                entity.Property(e => e.University).HasMaxLength(128);

                entity.Property(e => e.Username).HasMaxLength(128);

                entity.Property(e => e.Website)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('N/A')");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });

            modelBuilder.Entity<VwEventGetAll>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwEvent_GetAll");

                entity.Property(e => e.Background).HasMaxLength(256);

                entity.Property(e => e.City).HasMaxLength(128);

                entity.Property(e => e.Facebook).HasMaxLength(256);

                entity.Property(e => e.Language).HasMaxLength(128);

                entity.Property(e => e.Location).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Organization).HasMaxLength(128);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Region).HasMaxLength(128);

                entity.Property(e => e.Thumbnail).HasMaxLength(256);

                entity.Property(e => e.Website).HasMaxLength(256);
            });

            modelBuilder.Entity<VwEventGetPublished>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwEvent_GetPublished");

                entity.Property(e => e.Background).HasMaxLength(256);

                entity.Property(e => e.City).HasMaxLength(128);

                entity.Property(e => e.Facebook).HasMaxLength(256);

                entity.Property(e => e.Language).HasMaxLength(128);

                entity.Property(e => e.Location).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Organization).HasMaxLength(128);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Region).HasMaxLength(128);

                entity.Property(e => e.Thumbnail).HasMaxLength(256);

                entity.Property(e => e.Website).HasMaxLength(256);
            });

            modelBuilder.Entity<VwEventGetUnfinished>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwEvent_GetUnfinished");

                entity.Property(e => e.Background).HasMaxLength(256);

                entity.Property(e => e.City).HasMaxLength(128);

                entity.Property(e => e.Facebook).HasMaxLength(256);

                entity.Property(e => e.Language).HasMaxLength(128);

                entity.Property(e => e.Location).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Organization).HasMaxLength(128);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Region).HasMaxLength(128);

                entity.Property(e => e.Thumbnail).HasMaxLength(256);

                entity.Property(e => e.Website).HasMaxLength(256);
            });

            modelBuilder.Entity<VwEventGetUnpublished>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwEvent_GetUnpublished");

                entity.Property(e => e.Background).HasMaxLength(256);

                entity.Property(e => e.City).HasMaxLength(128);

                entity.Property(e => e.Facebook).HasMaxLength(256);

                entity.Property(e => e.Language).HasMaxLength(128);

                entity.Property(e => e.Location).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Organization).HasMaxLength(128);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Region).HasMaxLength(128);

                entity.Property(e => e.Thumbnail).HasMaxLength(256);

                entity.Property(e => e.Website).HasMaxLength(256);
            });

            modelBuilder.Entity<VwEventTag>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwEventTags");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.TagId).HasColumnName("TagID");
            });

            modelBuilder.Entity<VwStudentGovernmentGetAll>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwStudentGovernment_GetAll");

                entity.Property(e => e.City).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.Facebook).HasMaxLength(256);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Region).HasMaxLength(128);

                entity.Property(e => e.ShortName).HasMaxLength(32);

                entity.Property(e => e.University).HasMaxLength(128);

                entity.Property(e => e.Username).HasMaxLength(128);

                entity.Property(e => e.Website).HasMaxLength(256);
            });

            modelBuilder.Entity<VwTagGetAll>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwTag_GetAll");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}