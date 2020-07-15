using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sample.Application.RestService.Service.DBModel
{
    public partial class UpworkdbContext : DbContext
    {
        public UpworkdbContext()
        {
        }

        public UpworkdbContext(DbContextOptions<UpworkdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.ToTable("Tbl_Department");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifitedBy).HasMaxLength(50);

                entity.Property(e => e.ModifitedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.ToTable("Tbl_Employee");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.ModifitedBy).HasMaxLength(50);

                entity.Property(e => e.ModifitedDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Salary).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_Department");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
