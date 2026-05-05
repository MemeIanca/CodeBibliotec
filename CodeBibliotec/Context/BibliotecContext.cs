using System;
using System.Collections.Generic;
using CodeBibliotec.Domains;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Context;

public partial class BibliotecContext : DbContext
{
    public BibliotecContext()
    {
    }

    public BibliotecContext(DbContextOptions<BibliotecContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Avaliacao> Avaliacaos { get; set; }

    public virtual DbSet<Bibliotecarium> Bibliotecaria { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Favorito> Favoritos { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Aluno__645723A6E40E9EEB");

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Aluno).HasConstraintName("FK__Aluno__idUsuario__60A75C0F");
        });

        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Avaliaca__3213E83F66BD1F8C");

            entity.HasOne(d => d.IdAlunoNavigation).WithMany(p => p.Avaliacaos).HasConstraintName("FK__Avaliacao__idAlu__778AC167");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.Avaliacaos).HasConstraintName("FK__Avaliacao__idLiv__787EE5A0");
        });

        modelBuilder.Entity<Bibliotecarium>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Bibliote__645723A672C7560B");

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Bibliotecarium).HasConstraintName("FK__Bibliotec__idUsu__6477ECF3");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83F8645411E");
        });

        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorito__3213E83F8646C695");

            entity.HasOne(d => d.IdAlunoNavigation).WithMany(p => p.Favoritos).HasConstraintName("FK__Favorito__idAlun__7C4F7684");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.Favoritos).HasConstraintName("FK__Favorito__idLivr__7D439ABD");
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Livro__3213E83F7A5C3596");

            entity.HasMany(d => d.IdCategoria).WithMany(p => p.IdLivros)
                .UsingEntity<Dictionary<string, object>>(
                    "LivroCategorium",
                    r => r.HasOne<Categorium>().WithMany()
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("FK__LivroCate__idCat__6E01572D"),
                    l => l.HasOne<Livro>().WithMany()
                        .HasForeignKey("IdLivro")
                        .HasConstraintName("FK__LivroCate__idLiv__6D0D32F4"),
                    j =>
                    {
                        j.HasKey("IdLivro", "IdCategoria").HasName("PK__LivroCat__BB66949788D41703");
                        j.ToTable("LivroCategoria");
                        j.IndexerProperty<int>("IdLivro").HasColumnName("idLivro");
                        j.IndexerProperty<int>("IdCategoria").HasColumnName("idCategoria");
                    });
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reserva__3213E83FD8552550");

            entity.HasOne(d => d.IdAlunoNavigation).WithMany(p => p.Reservas).HasConstraintName("FK__Reserva__idAluno__71D1E811");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.Reservas).HasConstraintName("FK__Reserva__idLivro__72C60C4A");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F5F1F7085");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
