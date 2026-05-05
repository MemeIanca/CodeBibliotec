using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Domains;

[Table("Favorito")]
[Index("IdAluno", "IdLivro", Name = "UQ_Favorito", IsUnique = true)]
public partial class Favorito
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("dataFavorito")]
    public DateOnly DataFavorito { get; set; }

    [Column("idAluno")]
    public int IdAluno { get; set; }

    [Column("idLivro")]
    public int IdLivro { get; set; }

    [ForeignKey("IdAluno")]
    [InverseProperty("Favoritos")]
    public virtual Aluno IdAlunoNavigation { get; set; } = null!;

    [ForeignKey("IdLivro")]
    [InverseProperty("Favoritos")]
    public virtual Livro IdLivroNavigation { get; set; } = null!;
}
