using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APINewG.Entities
{
    public partial class testpbldbContext : DbContext
    {
        public testpbldbContext()
        {
        }

        public testpbldbContext(DbContextOptions<testpbldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Connection> Connections { get; set; } = null!;
        public virtual DbSet<ConnectionStatus> ConnectionStatuses { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<TagCategory> TagCategories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=testpbldb.database.windows.net;Initial Catalog=testpbldb;User ID=adminpbl;Password=123Vnpt123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Connection>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdConnectionStatusNavigation)
                    .WithMany(p => p.Connections)
                    .HasForeignKey(d => d.IdConnectionStatus)
                    .HasConstraintName("FK_IdConnectionStatus_Connections_ConnectionStatuses");

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.ConnectionIdLocalNavigations)
                    .HasForeignKey(d => d.IdLocal)
                    .HasConstraintName("FK_IdLocal_Connections_Users");

                entity.HasOne(d => d.IdTouristNavigation)
                    .WithMany(p => p.ConnectionIdTouristNavigations)
                    .HasForeignKey(d => d.IdTourist)
                    .HasConstraintName("FK_IdTourist_Connections_Users");
            });

            modelBuilder.Entity<ConnectionStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.NameFile).IsUnicode(false);

                entity.Property(e => e.Path).IsUnicode(false);

                entity.HasOne(d => d.IdReviewNavigation)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.IdReview)
                    .HasConstraintName("FK_IdReview_Files_Reviews");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdConnectionNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.IdConnection)
                    .HasConstraintName("FK_IdConnection_Reviews_Connections");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdTagCategoryNavigation)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.IdTagCategory)
                    .HasConstraintName("FK_IdTagCategory_Tags_TagCategories");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Bod).HasColumnName("BOD");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CCCD");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Tags).IsUnicode(false);

                entity.HasOne(d => d.IdAvatarFileNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdAvatarFile)
                    .HasConstraintName("FK_IdAvatarFile_Users_Files");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_IdRole_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
