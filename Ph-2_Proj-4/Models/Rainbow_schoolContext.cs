using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ph_2_Proj_4.Models
{
    public partial class Rainbow_schoolContext : DbContext
    {
        public Rainbow_schoolContext()
        {
        }

        public Rainbow_schoolContext(DbContextOptions<Rainbow_schoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Studentmark> Studentmarks { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DJMOSES;database=Rainbow_school;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("classes");

                entity.Property(e => e.Class1).HasColumnName("class");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StuId)
                    .HasName("S_id");

                entity.ToTable("student");

                entity.Property(e => e.StuId).HasColumnName("stu_id");

                entity.Property(e => e.StuClass).HasColumnName("stu_class");

                entity.Property(e => e.StuName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("stu_name");
            });

            modelBuilder.Entity<Studentmark>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__Studentm__CA1E5D78F60ACDD2");

                entity.Property(e => e.Sid).ValueGeneratedNever();

                entity.Property(e => e.Sname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubId)
                    .HasName("Su_id");

                entity.ToTable("subjects");

                entity.Property(e => e.SubId).HasColumnName("sub_id");

                entity.Property(e => e.SubName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sub_name");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TId)
                    .HasName("PK__Teachers__83B8138AD0CD8E21");

                entity.Property(e => e.TId)
                    .ValueGeneratedNever()
                    .HasColumnName("T_id");

                entity.Property(e => e.Sub)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("T_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
