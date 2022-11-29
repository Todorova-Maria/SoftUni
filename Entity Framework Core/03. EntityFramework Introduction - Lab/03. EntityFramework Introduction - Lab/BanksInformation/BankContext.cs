using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _03._EntityFramework_Introduction___Lab.BanksInformation
{
    public partial class BankContext : DbContext
    {
        public BankContext()
        {
        }

        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountHolder> AccountHolders { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<NotificationEmail> NotificationEmails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-9EQRASUR\\SQLEXPRESS;Integrated Security=true;Database=Bank");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Balance)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AccountHolder)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountHolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accounts_AccountHolders");
            });

            modelBuilder.Entity<AccountHolder>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ssn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SSN")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.NewSum).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.OldSum).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Logs__AccountId__5CD6CB2B");
            });

            modelBuilder.Entity<NotificationEmail>(entity =>
            {
                entity.Property(e => e.Body).IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RecipientNavigation)
                    .WithMany(p => p.NotificationEmails)
                    .HasForeignKey(d => d.Recipient)
                    .HasConstraintName("FK__Notificat__Recip__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
