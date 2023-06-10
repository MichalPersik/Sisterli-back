using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SisterLiDAL.Models;

public partial class SisterliContext : DbContext
{
    public SisterliContext()
    {
    }

    public SisterliContext(DbContextOptions<SisterliContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeChild> AgeChildren { get; set; }

    public virtual DbSet<Babysiter> Babysiters { get; set; }

    public virtual DbSet<HoursAvailble> HoursAvailbles { get; set; }

    public virtual DbSet<Mom> Moms { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<StatusRequest> StatusRequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DJJT4LA\\SQLEXPRESS;Database=Sisterli;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Hebrew_CI_AS");

        modelBuilder.Entity<AgeChild>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__age_chil__3213E83F690F488D");

            entity.ToTable("age_children");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
        });

        modelBuilder.Entity<Babysiter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__babysite__3213E83F67D6C5DE");

            entity.ToTable("babysiter");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.AgesChildrenId).HasColumnName("ages_children_id");
            entity.Property(e => e.HourlySalary).HasColumnName("hourly_salary");
            entity.Property(e => e.HoursAvailble).HasColumnName("hours_availble");
            entity.Property(e => e.IdUser)
                .HasMaxLength(15)
                .HasColumnName("id_user");
            entity.Property(e => e.Opinion).HasColumnName("opinion");
            entity.Property(e => e.School).HasColumnName("school");

            entity.HasOne(d => d.AgesChildren).WithMany(p => p.Babysiters)
                .HasForeignKey(d => d.AgesChildrenId)
                .HasConstraintName("FK_babysiter_age_children");

            entity.HasOne(d => d.HoursAvailbleNavigation).WithMany(p => p.Babysiters)
                .HasForeignKey(d => d.HoursAvailble)
                .HasConstraintName("FK__babysiter__hours__3E52440B");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Babysiters)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__babysiter__id_us__3D5E1FD2");
        });

        modelBuilder.Entity<HoursAvailble>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hours_av__3213E83F430D3276");

            entity.ToTable("hours_availble");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Availble).HasColumnName("availble");
        });

        modelBuilder.Entity<Mom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mom__3213E83FB2DD2454");

            entity.ToTable("mom");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.HourlySalary).HasColumnName("hourly_salary");
            entity.Property(e => e.IdAgeChildren).HasColumnName("id_age_children");
            entity.Property(e => e.IdUser)
                .HasMaxLength(15)
                .HasColumnName("id_user");
            entity.Property(e => e.IsSleep).HasColumnName("is_sleep");
            entity.Property(e => e.IsWifi).HasColumnName("is_wifi");
            entity.Property(e => e.NumChildren).HasColumnName("num_children");

            entity.HasOne(d => d.IdAgeChildrenNavigation).WithMany(p => p.Moms)
                .HasForeignKey(d => d.IdAgeChildren)
                .HasConstraintName("FK_mom_age_children");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Moms)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_mom_users1");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__request__3213E83F264810D6");

            entity.ToTable("request");

            entity.HasIndex(e => e.Status, "IX_request");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BeginningTime).HasColumnName("beginning_time");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Day)
                .HasColumnType("date")
                .HasColumnName("day");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.HourlySalary).HasColumnName("hourly_salary");
            entity.Property(e => e.IdAgeChildren).HasColumnName("id_age_children");
            entity.Property(e => e.IdBs).HasColumnName("id_bs");
            entity.Property(e => e.IdMom).HasColumnName("id_mom");
            entity.Property(e => e.IsSleep).HasColumnName("is_sleep");
            entity.Property(e => e.IsWifi).HasColumnName("is_wifi");
            entity.Property(e => e.NumChildren).HasColumnName("num_children");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdAgeChildrenNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdAgeChildren)
                .HasConstraintName("FK_request_age_children");

            entity.HasOne(d => d.IdBsNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdBs)
                .HasConstraintName("FK_request_babysiter");

            entity.HasOne(d => d.IdMomNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdMom)
                .HasConstraintName("FK_request_mom");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK_request_request");
        });

        modelBuilder.Entity<StatusRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__statusRe__3213E83F512F3398");

            entity.ToTable("statusRequest");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasMaxLength(15)
                .HasColumnName("id");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FristName).HasColumnName("frist_name");
            entity.Property(e => e.GeneryInfo).HasColumnName("genery_info");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Street).HasColumnName("street");
            entity.Property(e => e.Tel).HasColumnName("tel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
