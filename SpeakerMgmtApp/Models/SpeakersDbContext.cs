using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpeakerMgmtApp.Models
{
    public partial class SpeakersDbContext : DbContext
    {
        public SpeakersDbContext()
        {
        }

        public SpeakersDbContext(DbContextOptions<SpeakersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Speaker> Speakers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TTLN1EM6;Database=ConferenceSpeakersDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.ToTable("Speaker");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactFirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactLastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Experience)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HotelName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePictureData).HasColumnType("varbinary(max)");

                entity.Property(e => e.ProfilePictureDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePictureFileType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePictureName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePrictureExtension)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpeakerFirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpeakerLastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpeakingDate).HasColumnType("datetime");

                entity.Property(e => e.Venue)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
