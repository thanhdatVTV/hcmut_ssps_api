using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HCMUT_SSPS.Models;

public partial class HcmutSspsContext : DbContext
{
    public HcmutSspsContext()
    {
    }

    public HcmutSspsContext(DbContextOptions<HcmutSspsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblFileType> TblFileTypes { get; set; }

    public virtual DbSet<TblLogLogin> TblLogLogins { get; set; }

    public virtual DbSet<TblPageSize> TblPageSizes { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserRole> TblUserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Phuong;Database=HCMUT_SSPS;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblFileType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_File__3214EC0723AB1C91");

            entity.ToTable("tbl_FileType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblLogLogin>(entity =>
        {
            entity.ToTable("tbl_LogLogin");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblPageSize>(entity =>
        {
            entity.ToTable("tbl_PageSize");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.PageSizeName).HasMaxLength(10);
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.ToTable("tbl_Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.RoleName).HasMaxLength(250);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.ToTable("tbl_User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CodeId).HasMaxLength(50);
            entity.Property(e => e.CourseName).HasMaxLength(250);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.FacultyName).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.FullName).HasMaxLength(500);
            entity.Property(e => e.LastName).HasMaxLength(250);
        });

        modelBuilder.Entity<TblUserRole>(entity =>
        {
            entity.ToTable("tbl_UserRole");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
