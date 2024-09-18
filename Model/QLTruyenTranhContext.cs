using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIAnimeApp.Model
{
    public partial class QLTruyenTranhContext : DbContext
    {
        public QLTruyenTranhContext()
        {
        }

        public QLTruyenTranhContext(DbContextOptions<QLTruyenTranhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<Story> Stories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=QLTruyenTranh;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChapterName).HasMaxLength(500);

                entity.Property(e => e.CreateAt).HasColumnType("date");

                entity.HasOne(d => d.IdStoryNavigation)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.IdStory)
                    .HasConstraintName("FK_Chapters_Stories");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.Content).HasMaxLength(250);

                entity.Property(e => e.CreateAt).HasColumnType("date");

                entity.Property(e => e.UserName).HasMaxLength(500);

                entity.HasOne(d => d.IdStoryNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdStory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Stories");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.HasOne(d => d.IdChapNavigation)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.IdChap)
                    .HasConstraintName("FK_Pages_Chapters");
            });

            modelBuilder.Entity<Story>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Author).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.Summary).HasColumnType("ntext");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Stories)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK_Stories_Categories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
