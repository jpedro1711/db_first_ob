using Microsoft.EntityFrameworkCore;

namespace efcore_dbfirst.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emprestimo> Emprestimos { get; set; }

    public virtual DbSet<GeneroLivro> GeneroLivros { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=dumb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emprestimo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresti__3214EC0716D3D01F");

            entity.ToTable("Emprestimo");

            entity.Property(e => e.DataDevolucao).HasColumnType("datetime");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Emprestimos)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emprestimo_Reserva");
        });

        modelBuilder.Entity<GeneroLivro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GeneroLi__3214EC0758586199");

            entity.ToTable("GeneroLivro");

            entity.Property(e => e.Nome).HasMaxLength(255);
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Livro__3214EC07EBF36809");

            entity.ToTable("Livro");

            entity.Property(e => e.Autor).HasMaxLength(255);
            entity.Property(e => e.SomaTotalAvaliacoes).HasDefaultValue(0);
            entity.Property(e => e.Titulo).HasMaxLength(255);
            entity.Property(e => e.TotalAvaliacoes).HasDefaultValue(0);

            entity.HasOne(d => d.GeneroLivro).WithMany(p => p.Livros)
                .HasForeignKey(d => d.GeneroLivroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Livro_GeneroLivro");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reserva__3214EC0713779B07");

            entity.ToTable("Reserva");

            entity.Property(e => e.DataReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Usuario");

            entity.HasMany(d => d.Livros).WithMany(p => p.Reservas)
                .UsingEntity<Dictionary<string, object>>(
                    "ReservaLivro",
                    r => r.HasOne<Livro>().WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ReservaLivro_Livro"),
                    l => l.HasOne<Reserva>().WithMany()
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ReservaLivro_Reserva"),
                    j =>
                    {
                        j.HasKey("ReservaId", "LivroId");
                        j.ToTable("ReservaLivro");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07F218A91A");

            entity.ToTable("Usuario");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Nome).HasMaxLength(255);
            entity.Property(e => e.Senha).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
