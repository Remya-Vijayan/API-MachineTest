using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Models;

public partial class LoanManagementSystemContext : DbContext
{
    public LoanManagementSystemContext()
    {
    }

    public LoanManagementSystemContext(DbContextOptions<LoanManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BackgroundVerification> BackgroundVerifications { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Help> Helps { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<LoanVerification> LoanVerifications { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog =LoanManagementSystem; Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BackgroundVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__Backgrou__306D4927CE9F4EC1");

            entity.ToTable("BackgroundVerification");

            entity.Property(e => e.VerificationId).HasColumnName("VerificationID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.LoanOfficerId).HasColumnName("LoanOfficerID");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Loan).WithMany(p => p.BackgroundVerifications)
                .HasForeignKey(d => d.LoanId)
                .HasConstraintName("FK__Backgroun__LoanI__3A81B327");

            entity.HasOne(d => d.LoanOfficer).WithMany(p => p.BackgroundVerifications)
                .HasForeignKey(d => d.LoanOfficerId)
                .HasConstraintName("FK__Backgroun__LoanO__3B75D760");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF63B64C998");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Comments).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Feedback__UserID__4BAC3F29");
        });

        modelBuilder.Entity<Help>(entity =>
        {
            entity.HasKey(e => e.HelpId).HasName("PK__Help__90E3232E75C9072D");

            entity.ToTable("Help");

            entity.Property(e => e.HelpId).HasColumnName("HelpID");
            entity.Property(e => e.Answer).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Question).HasColumnType("text");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Helps)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Help_Users");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__Loans__4F5AD43782C6234A");

            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Loans)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Loans__UserID__33D4B598");
        });

        modelBuilder.Entity<LoanVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__LoanVeri__306D4927F512D472");

            entity.ToTable("LoanVerification");

            entity.Property(e => e.VerificationId).HasColumnName("VerificationID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.LoanOfficerId).HasColumnName("LoanOfficerID");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Loan).WithMany(p => p.LoanVerifications)
                .HasForeignKey(d => d.LoanId)
                .HasConstraintName("FK__LoanVerif__LoanI__4222D4EF");

            entity.HasOne(d => d.LoanOfficer).WithMany(p => p.LoanVerifications)
                .HasForeignKey(d => d.LoanOfficerId)
                .HasConstraintName("FK__LoanVerif__LoanO__4316F928");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AD959E848");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B61600BC9F5A8").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC60584376");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E47A76E7D3").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105347B4B4A39").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__2D27B809");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
