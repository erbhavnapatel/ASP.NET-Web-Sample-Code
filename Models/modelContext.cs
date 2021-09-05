using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CustomerOrderWebApplication.Models
{
    public partial class modelContext : DbContext
    {
        public modelContext()
        {
        }

        public modelContext(DbContextOptions<modelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-N7QM1DJ9;Initial Catalog=model;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(e => e.AgentCode)
                    .HasName("PK__Agent__50A798568FB780A9");

                entity.Property(e => e.AgentCode)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.AgentCountry).HasMaxLength(30);

                entity.Property(e => e.AgentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Area).HasMaxLength(30);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustCode)
                    .HasName("PK__Customer__4D554DC1EE7457CA");

                entity.Property(e => e.CustCode)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.AgentCode)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.Country).HasMaxLength(30);

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.WorkingArea).HasMaxLength(30);

                entity.HasOne(d => d.AgentCodeNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.AgentCode)
                    .HasConstraintName("FK_Customer_Agent");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("PK__Order__C3907C7434A88A75");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.AgentCode)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.CustCode)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDesc).HasMaxLength(300);

                entity.HasOne(d => d.AgentCodeNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AgentCode)
                    .HasConstraintName("FK_Order_Agent");

                entity.HasOne(d => d.CustCodeNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustCode)
                    .HasConstraintName("FK_Order_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
