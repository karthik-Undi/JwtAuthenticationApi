using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace JwtAuthenticationApi.Model
{
    public partial class JwtAuthenticationContext : DbContext
    {
        public JwtAuthenticationContext()
        {
        }

        public JwtAuthenticationContext(DbContextOptions<JwtAuthenticationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginDetails> LoginDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-328\\MSSQLSERVER1;Database=JwtAuthentication;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginDetails>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__LoginDet__F3DBC573811867FB");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
