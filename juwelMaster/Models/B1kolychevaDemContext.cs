using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace juwelMaster;

public partial class B1kolychevaDemContext : DbContext
{
    public B1kolychevaDemContext()
    {
    }

    public B1kolychevaDemContext(DbContextOptions<B1kolychevaDemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<HomeTechType> HomeTechTypes { get; set; }

    public virtual DbSet<Master> Masters { get; set; }

    public virtual DbSet<RepairPart> RepairParts { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KT95TVL;DataBase=b1kolychevaDem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__81A2CB81AE1DBA4C");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("clientID");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fio");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__CDDE91BDDBFFB34A");

            entity.Property(e => e.CommentId)
                .ValueGeneratedNever()
                .HasColumnName("commentID");
            entity.Property(e => e.MasterId).HasColumnName("masterID");
            entity.Property(e => e.MessageComments)
                .HasColumnType("text")
                .HasColumnName("messageComments");
            entity.Property(e => e.RequestId).HasColumnName("requestID");

            entity.HasOne(d => d.Master).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MasterId)
                .HasConstraintName("FK__Comments__master__3E52440B");

            entity.HasOne(d => d.Request).WithMany(p => p.Comments)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__Comments__reques__3F466844");
        });

        modelBuilder.Entity<HomeTechType>(entity =>
        {
            entity.HasKey(e => e.HomeTechTypeId).HasName("PK__HomeTech__B93FD7F990FEE21E");

            entity.HasIndex(e => e.HomeTechType1, "UQ__HomeTech__FE0C2376732E4F97").IsUnique();

            entity.Property(e => e.HomeTechTypeId)
                .ValueGeneratedNever()
                .HasColumnName("homeTechTypeID");
            entity.Property(e => e.HomeTechType1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("homeTechType");
        });

        modelBuilder.Entity<Master>(entity =>
        {
            entity.HasKey(e => e.MasterId).HasName("PK__Masters__D7BE0B4B9FCEFE4F");

            entity.Property(e => e.MasterId)
                .ValueGeneratedNever()
                .HasColumnName("masterID");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fio");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<RepairPart>(entity =>
        {
            entity.HasKey(e => e.RepairPartId).HasName("PK__RepairPa__2421DD68EBE24023");

            entity.Property(e => e.RepairPartId).HasColumnName("repairPartID");
            entity.Property(e => e.PartName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("partName");
            entity.Property(e => e.RequestId).HasColumnName("requestID");

            entity.HasOne(d => d.Request).WithMany(p => p.RepairPartsNavigation)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__RepairPar__reque__44FF419A");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Requests__E3C5DE512088821C");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("requestID");
            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.CompletionDate).HasColumnName("completionDate");
            entity.Property(e => e.HomeTechModel)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("homeTechModel");
            entity.Property(e => e.HomeTechType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("homeTechType");
            entity.Property(e => e.MasterId).HasColumnName("masterID");
            entity.Property(e => e.ProblemDescryption)
                .HasColumnType("text")
                .HasColumnName("problemDescryption");
            entity.Property(e => e.RepairParts)
                .HasColumnType("text")
                .HasColumnName("repairParts");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("requestStatus");
            entity.Property(e => e.StartDate).HasColumnName("startDate");

            entity.HasOne(d => d.Client).WithMany(p => p.RequestClients)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Requests__client__3B75D760");

            entity.HasOne(d => d.Master).WithMany(p => p.RequestMasters)
                .HasForeignKey(d => d.MasterId)
                .HasConstraintName("FK__Requests__master__3A81B327");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CDFBB9C74C3");

            entity.HasIndex(e => e.LoginUser, "UQ__Users__CE48A624ED5CB6C5").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userID");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fio");
            entity.Property(e => e.LoginUser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("loginUser");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passwordUser");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.TypeRole)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("typeRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
