using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProDobro.API.Models
{
    public partial class ProDobroContext : DbContext
    {
        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<EventsType> EventsType { get; set; }
        public virtual DbSet<Ssotypes> Ssotypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersTypes> UsersTypes { get; set; }

        public ProDobroContext(DbContextOptions<ProDobroContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Calendar)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calendar_Events1");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_EventsType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Users");
            });

            modelBuilder.Entity<EventsType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Ssotypes>(entity =>
            {
                entity.ToTable("SSOTypes");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Ssokey)
                    .IsRequired()
                    .HasColumnName("SSOKey");

                entity.Property(e => e.SsotypeId).HasColumnName("SSOTypeId");

                entity.HasOne(d => d.Ssotype)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.SsotypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_SSOTypes");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UsersTypes");
            });

            modelBuilder.Entity<UsersTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(10)");
            });
        }
    }
}
