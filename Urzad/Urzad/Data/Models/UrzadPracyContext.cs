using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Urzad.Data.Models
{
    public partial class UrzadPracyContext : DbContext
    {
        public UrzadPracyContext()
        {
        }

        public UrzadPracyContext(DbContextOptions<UrzadPracyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataRejestracji> DataRejestracji { get; set; }
        public virtual DbSet<KategoriaOferty> KategoriaOferty { get; set; }
        public virtual DbSet<Kwalifikacje> Kwalifikacje { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Oferty> Oferty { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<PosiadaneKwalifikacje> PosiadaneKwalifikacje { get; set; }
        public virtual DbSet<TypOferty> TypOferty { get; set; }
        public virtual DbSet<Wniosek> Wniosek { get; set; }
        public virtual DbSet<WymaganeOsiągnięcia> WymaganeOsiągnięcia { get; set; }
        public object LoginResponse { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=UrzadPracy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataRejestracji>(entity =>
            {
                entity.HasKey(e => e.IdDaty)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Data_rejestracji");

                entity.Property(e => e.IdDaty).HasColumnName("Id_daty");

                entity.Property(e => e.DataKońcowa)
                    .HasColumnName("Data_końcowa")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataRejestracji1)
                    .HasColumnName("Data_rejestracji")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdOsoby).HasColumnName("Id_osoby");

                entity.HasOne(d => d.IdOsobyNavigation)
                    .WithMany(p => p.DataRejestracji)
                    .HasForeignKey(d => d.IdOsoby)
                    .HasConstraintName("FK_DATA_REJ_DATA_REJE_OSOBA");
            });

            modelBuilder.Entity<KategoriaOferty>(entity =>
            {
                entity.HasKey(e => e.IdKategorii)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Kategoria_oferty");

                entity.Property(e => e.IdKategorii).HasColumnName("Id_kategorii");

                entity.Property(e => e.IdTypu).HasColumnName("Id_typu");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTypuNavigation)
                    .WithMany(p => p.KategoriaOferty)
                    .HasForeignKey(d => d.IdTypu)
                    .HasConstraintName("FK_KATEGORI_TYP_TYP_OFER");
            });

            modelBuilder.Entity<Kwalifikacje>(entity =>
            {
                entity.HasKey(e => e.IdKwalifikacji)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.IdKwalifikacji).HasColumnName("Id_kwalifikacji");

                entity.Property(e => e.Opis)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.IdLogin)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.IdLogin).HasColumnName("Id_login");

                entity.Property(e => e.Hasło)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdOsoby).HasColumnName("Id_osoby");

                entity.Property(e => e.Login1)
                    .HasColumnName("Login")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uprawnienia)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOsobyNavigation)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.IdOsoby)
                    .HasConstraintName("FK_LOGIN_LOGIN_OSOBA");
            });

            modelBuilder.Entity<Oferty>(entity =>
            {
                entity.HasKey(e => e.IdOferty)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.IdOferty).HasColumnName("Id_oferty");

                entity.Property(e => e.IdKategorii).HasColumnName("Id_kategorii");

                entity.Property(e => e.OpisOferty)
                    .HasColumnName("Opis_oferty")
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdKategoriiNavigation)
                    .WithMany(p => p.Oferty)
                    .HasForeignKey(d => d.IdKategorii)
                    .HasConstraintName("FK_OFERTY_KATEGORIA_KATEGORI");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasKey(e => e.IdOsoby)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.IdOsoby).HasColumnName("Id_osoby");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnName("Data_urodzenia")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Pesel)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Płeć)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Wykształcenie)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PosiadaneKwalifikacje>(entity =>
            {
                entity.HasKey(e => new { e.IdOsoby, e.IdKwalifikacji });

                entity.ToTable("Posiadane_kwalifikacje");

                entity.Property(e => e.IdOsoby).HasColumnName("Id_osoby");

                entity.Property(e => e.IdKwalifikacji).HasColumnName("Id_kwalifikacji");

                entity.HasOne(d => d.IdKwalifikacjiNavigation)
                    .WithMany(p => p.PosiadaneKwalifikacje)
                    .HasForeignKey(d => d.IdKwalifikacji)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSIADAN_POSIADANE_KWALIFIK");

                entity.HasOne(d => d.IdOsobyNavigation)
                    .WithMany(p => p.PosiadaneKwalifikacje)
                    .HasForeignKey(d => d.IdOsoby)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSIADAN_POSIADANE_OSOBA");
            });

            modelBuilder.Entity<TypOferty>(entity =>
            {
                entity.HasKey(e => e.IdTypu)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("Typ_oferty");

                entity.Property(e => e.IdTypu).HasColumnName("Id_typu");

                entity.Property(e => e.Opis)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wniosek>(entity =>
            {
                entity.HasKey(e => new { e.IdOsoby, e.IdKategorii });

                entity.Property(e => e.IdOsoby).HasColumnName("Id_osoby");

                entity.Property(e => e.IdKategorii).HasColumnName("Id_kategorii");

                entity.HasOne(d => d.IdKategoriiNavigation)
                    .WithMany(p => p.Wniosek)
                    .HasForeignKey(d => d.IdKategorii)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WNIOSEK_WNIOSEK2_KATEGORI");

                entity.HasOne(d => d.IdOsobyNavigation)
                    .WithMany(p => p.Wniosek)
                    .HasForeignKey(d => d.IdOsoby)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WNIOSEK_WNIOSEK_OSOBA");
            });

            modelBuilder.Entity<WymaganeOsiągnięcia>(entity =>
            {
                entity.HasKey(e => new { e.IdKwalifikacji, e.IdOferty });

                entity.ToTable("Wymagane_osiągnięcia");

                entity.Property(e => e.IdKwalifikacji).HasColumnName("Id_kwalifikacji");

                entity.Property(e => e.IdOferty).HasColumnName("Id_oferty");

                entity.HasOne(d => d.IdKwalifikacjiNavigation)
                    .WithMany(p => p.WymaganeOsiągnięcia)
                    .HasForeignKey(d => d.IdKwalifikacji)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WYMAGANE_WYMAGANE__KWALIFIK");

                entity.HasOne(d => d.IdOfertyNavigation)
                    .WithMany(p => p.WymaganeOsiągnięcia)
                    .HasForeignKey(d => d.IdOferty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WYMAGANE_WYMAGANE__OFERTY");
            });
        }
    }
}
