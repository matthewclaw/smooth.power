using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Extensions.Configuration;
using Smooth.Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Smooth.Power.Logic.Context
{
    public class SmoothPowerContext : DbContext
    {
        private Settings _settings;

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<DeviceEntity> Devices { get; set; }
        public DbSet<PhaseEntity> Phases { get; set; }
        public DbSet<ReadingEntity> Readings { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ErrorEntity> Errors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = Settings.DefaultConnectionString;
            optionsBuilder.UseMySQL(conStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientEntity>(entity =>
            {
                entity.BaseProperties();
                entity.Property(e => e.Name);
                entity.Property(e => e.ContactNumber);
                entity.Property(e => e.ContactEmail);
                entity.Property(e => e.Address1);
                entity.Property(e => e.Address2);
                entity.Property(e => e.Address3);
                entity.Property(e => e.Address4);

            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.BaseProperties();
                entity.HasAlternateKey(e => e.Email);
                entity.Property(e => e.Name);
                entity.Property(e => e.LastName);
                entity.Property(e => e.Email);
                entity.Property(e => e.Password);
                entity.Property(e => e.IsAdmin);
                entity.Property(e => e.IsClientAdmin);
                entity.HasOne(e => e.Client)
                        .WithMany(p => p.Users);
            });

            modelBuilder.Entity<ReadingEntity>(entity =>
            {
                entity.BaseProperties();
                entity.Property(e => e.SystemState);
                entity.HasOne(e => e.Device)
                        .WithMany(p => p.Readings);
            });

            modelBuilder.Entity<PhaseEntity>(entity =>
            {
                entity.BaseProperties();
                entity.Property(e => e.Voltage);
                entity.Property(e => e.Current);
                entity.Property(e => e.PFCurrently);
                entity.Property(e => e.PFCorrectedFor);
                entity.Property(e => e.PowerUsage);
                entity.Property(e => e.VAHUsedThisMonthToDate);
                entity.Property(e => e.VAHSavedThisMonthToDate);
                entity.HasOne(e => e.Reading)
                        .WithMany(p => p.Phases);
            });

            modelBuilder.Entity<DeviceEntity>(entity =>
            {
                entity.BaseProperties();
                entity.HasKey(e => e.SerialNumber);
                entity.Property(e => e.LastKnownStatus);
                entity.Property(e => e.Address1);
                entity.Property(e => e.Address2);
                entity.Property(e => e.Address3);
                entity.Property(e => e.Address4);
                entity.Property(e => e.Site);
                entity.HasOne(e => e.Client)
                        .WithMany(p => p.Devices);
            });

            modelBuilder.Entity<ErrorEntity>(entity =>
            {
                entity.BaseProperties();
                entity.Property(e => e.Data);
                entity.HasOne(e => e.Reading)
                        .WithMany(p => p.Errors);
            });

        }
    }
    public static class ContextExtensions
    {
        public static void BaseProperties<T>(this EntityTypeBuilder<T> entity) where T : BaseEntity
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.LastUpdateTime)
                .HasValueGenerator<LastUpdateTimeGenerator>()
                .ValueGeneratedOnUpdate();
        }
    }
    class LastUpdateTimeGenerator: ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object NextValue([NotNullAttribute] EntityEntry entry)
        {
            return DateTime.Now;
        }
    }
}
