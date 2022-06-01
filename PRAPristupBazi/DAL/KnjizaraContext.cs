using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PRAPristupBazi.Models;

namespace PRAPristupBazi.DAL
{
    public partial class KnjizaraContext : DbContext
    {
        public KnjizaraContext(DbContextOptions<KnjizaraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<Drzava> Drzavas { get; set; } = null!;
        public virtual DbSet<Grad> Grads { get; set; } = null!;
        public virtual DbSet<Izdavac> Izdavacs { get; set; } = null!;
        public virtual DbSet<Knjiga> Knjigas { get; set; } = null!;
        public virtual DbSet<Knjizara> Knjizaras { get; set; } = null!;
        public virtual DbSet<Korisnik> Korisniks { get; set; } = null!;
        public virtual DbSet<Osoba> Osobas { get; set; } = null!;
        public virtual DbSet<Posudba> Posudbas { get; set; } = null!;
        public virtual DbSet<Racun> Racuns { get; set; } = null!;
        public virtual DbSet<StanjeKnjige> StanjeKnjiges { get; set; } = null!;
        public virtual DbSet<Stavka> Stavkas { get; set; } = null!;
        public virtual DbSet<UlogaUaplikaciji> UlogaUaplikacijis { get; set; } = null!;
        public virtual DbSet<ZakasninaPoDanu> ZakasninaPoDanus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"Server={System.Environment.MachineName}; Database=PRAKnjizara; Trusted_Connection=True; MultipleActiveResultSets=True")
                              .UseLazyLoadingProxies()
                              .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.Idautor)
                    .HasName("PK__Autor__5DC53A1387C3B1DE");

                entity.ToTable("Autor");

                entity.Property(e => e.Idautor).HasColumnName("IDAutor");

                entity.Property(e => e.Ime).HasMaxLength(100);

                entity.Property(e => e.Prezime).HasMaxLength(100);
            });

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.HasKey(e => e.Iddrzava)
                    .HasName("PK__Drzava__ECD2F9721724CC8B");

                entity.ToTable("Drzava");

                entity.Property(e => e.Iddrzava).HasColumnName("IDDrzava");

                entity.Property(e => e.Naziv).HasMaxLength(100);
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.HasKey(e => e.Idgrad)
                    .HasName("PK__Grad__D2F129AD9BC301E5");

                entity.ToTable("Grad");

                entity.Property(e => e.Idgrad).HasColumnName("IDGrad");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv).HasMaxLength(100);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grads)
                    .HasForeignKey(d => d.DrzavaId)
                    .HasConstraintName("FK__Grad__DrzavaID__30F848ED");
            });

            modelBuilder.Entity<Izdavac>(entity =>
            {
                entity.HasKey(e => e.Idizdavac)
                    .HasName("PK__Izdavac__E3076D10725C61C8");

                entity.ToTable("Izdavac");

                entity.Property(e => e.Idizdavac).HasColumnName("IDIzdavac");

                entity.Property(e => e.Naziv).HasMaxLength(100);
            });

            modelBuilder.Entity<Knjiga>(entity =>
            {
                entity.HasKey(e => e.Idknjiga)
                    .HasName("PK__Knjiga__9C73C072804ACEA5");

                entity.ToTable("Knjiga");

                entity.Property(e => e.Idknjiga).HasColumnName("IDKnjiga");

                entity.Property(e => e.AutorId).HasColumnName("AutorID");

                entity.Property(e => e.CijenaZaKupovinu).HasColumnType("money");

                entity.Property(e => e.CijenaZaNajam).HasColumnType("money");

                entity.Property(e => e.DatumBrisanja).HasColumnType("datetime");

                entity.Property(e => e.DatumDodavanja).HasColumnType("datetime");

                entity.Property(e => e.Izdanje).HasMaxLength(100);

                entity.Property(e => e.IzdavacId).HasColumnName("IzdavacID");

                entity.Property(e => e.Naslov).HasMaxLength(100);

                entity.Property(e => e.Slika).HasMaxLength(100);

                entity.Property(e => e.StanjeKnjigeId).HasColumnName("StanjeKnjigeID");

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Knjigas)
                    .HasForeignKey(d => d.AutorId)
                    .HasConstraintName("FK__Knjiga__AutorID__2A4B4B5E");

                entity.HasOne(d => d.Izdavac)
                    .WithMany(p => p.Knjigas)
                    .HasForeignKey(d => d.IzdavacId)
                    .HasConstraintName("FK__Knjiga__IzdavacI__2B3F6F97");

                entity.HasOne(d => d.StanjeKnjige)
                    .WithMany(p => p.Knjigas)
                    .HasForeignKey(d => d.StanjeKnjigeId)
                    .HasConstraintName("FK__Knjiga__StanjeKn__2C3393D0");
            });

            modelBuilder.Entity<Knjizara>(entity =>
            {
                entity.HasKey(e => e.Idknjizara)
                    .HasName("PK__Knjizara__3E7E15FDDF3A9D81");

                entity.ToTable("Knjizara");

                entity.Property(e => e.Idknjizara).HasColumnName("IDKnjizara");

                entity.Property(e => e.Adresa).HasMaxLength(100);

                entity.Property(e => e.Iban)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("IBAN");

                entity.Property(e => e.Logo).HasMaxLength(100);

                entity.Property(e => e.Naziv).HasMaxLength(100);

                entity.Property(e => e.Oib)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("OIB")
                    .IsFixedLength();

                entity.Property(e => e.UvjetiKoristenja).HasMaxLength(100);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasKey(e => e.Idkorisnik)
                    .HasName("PK__Korisnik__6F9CD5C43E2BFDCA");

                entity.ToTable("Korisnik");

                entity.Property(e => e.Idkorisnik).HasColumnName("IDKorisnik");

                entity.Property(e => e.DatumBrisanja).HasColumnType("datetime");

                entity.Property(e => e.DatumRegistracije).HasColumnType("datetime");

                entity.Property(e => e.Lozinka)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OsobaId).HasColumnName("OsobaID");

                entity.Property(e => e.SifraKorisnika)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UlogaUaplikacijiId).HasColumnName("UlogaUAplikacijiID");

                entity.HasOne(d => d.Osoba)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.OsobaId)
                    .HasConstraintName("FK__Korisnik__OsobaI__38996AB5");

                entity.HasOne(d => d.UlogaUaplikaciji)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.UlogaUaplikacijiId)
                    .HasConstraintName("FK__Korisnik__UlogaU__398D8EEE");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasKey(e => e.Idosoba)
                    .HasName("PK__Osoba__30ABD14DD0C1689F");

                entity.ToTable("Osoba");

                entity.Property(e => e.Idosoba).HasColumnName("IDOsoba");

                entity.Property(e => e.Adresa).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime).HasMaxLength(100);

                entity.Property(e => e.PostanskiBroj).HasMaxLength(100);

                entity.Property(e => e.Prezime).HasMaxLength(100);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Osobas)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK__Osoba__GradID__33D4B598");
            });

            modelBuilder.Entity<Posudba>(entity =>
            {
                entity.HasKey(e => e.Idposudba)
                    .HasName("PK__Posudba__BE491FFD2545357D");

                entity.ToTable("Posudba");

                entity.Property(e => e.Idposudba).HasColumnName("IDPosudba");

                entity.Property(e => e.DatumPosudbe).HasColumnType("datetime");

                entity.Property(e => e.DatumVracanja).HasColumnType("datetime");

                entity.Property(e => e.KnjigaId).HasColumnName("KnjigaID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.PeriodPosudbe).HasColumnType("datetime");

                entity.Property(e => e.ZakasninaPoDanuId).HasColumnName("ZakasninaPoDanuID");

                entity.HasOne(d => d.Knjiga)
                    .WithMany(p => p.Posudbas)
                    .HasForeignKey(d => d.KnjigaId)
                    .HasConstraintName("FK__Posudba__KnjigaI__3E52440B");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Posudbas)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK__Posudba__Korisni__3F466844");

                entity.HasOne(d => d.ZakasninaPoDanu)
                    .WithMany(p => p.Posudbas)
                    .HasForeignKey(d => d.ZakasninaPoDanuId)
                    .HasConstraintName("FK__Posudba__Zakasni__403A8C7D");
            });

            modelBuilder.Entity<Racun>(entity =>
            {
                entity.HasKey(e => e.Idracun)
                    .HasName("PK__Racun__84F24C969EB39612");

                entity.ToTable("Racun");

                entity.Property(e => e.Idracun).HasColumnName("IDRacun");

                entity.Property(e => e.DatumIzdavanja).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Racuns)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK__Racun__KorisnikI__4316F928");
            });

            modelBuilder.Entity<StanjeKnjige>(entity =>
            {
                entity.HasKey(e => e.IdstanjeKnjige)
                    .HasName("PK__StanjeKn__C4513EF27461B4B2");

                entity.ToTable("StanjeKnjige");

                entity.Property(e => e.IdstanjeKnjige).HasColumnName("IDStanjeKnjige");

                entity.Property(e => e.Stanje).HasMaxLength(10);
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.HasKey(e => e.Idstavka)
                    .HasName("PK__Stavka__8A2E82581A2E225B");

                entity.ToTable("Stavka");

                entity.Property(e => e.Idstavka).HasColumnName("IDStavka");

                entity.Property(e => e.KnjigaId).HasColumnName("KnjigaID");

                entity.Property(e => e.RacunId).HasColumnName("RacunID");

                entity.HasOne(d => d.Knjiga)
                    .WithMany(p => p.Stavkas)
                    .HasForeignKey(d => d.KnjigaId)
                    .HasConstraintName("FK__Stavka__KnjigaID__46E78A0C");

                entity.HasOne(d => d.Racun)
                    .WithMany(p => p.Stavkas)
                    .HasForeignKey(d => d.RacunId)
                    .HasConstraintName("FK__Stavka__RacunID__45F365D3");
            });

            modelBuilder.Entity<UlogaUaplikaciji>(entity =>
            {
                entity.HasKey(e => e.IdulogaUaplikaciji)
                    .HasName("PK__UlogaUAp__078F23A894ABB7D1");

                entity.ToTable("UlogaUAplikaciji");

                entity.Property(e => e.IdulogaUaplikaciji).HasColumnName("IDUlogaUAplikaciji");

                entity.Property(e => e.Uloga).HasMaxLength(100);
            });

            modelBuilder.Entity<ZakasninaPoDanu>(entity =>
            {
                entity.HasKey(e => e.IdzakasninaPoDanu)
                    .HasName("PK__Zakasnin__653DDE5AE707E202");

                entity.ToTable("ZakasninaPoDanu");

                entity.Property(e => e.IdzakasninaPoDanu).HasColumnName("IDZakasninaPoDanu");

                entity.Property(e => e.Zakasnina).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
