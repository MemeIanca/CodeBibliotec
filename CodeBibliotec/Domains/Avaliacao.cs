using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Domains;

[Table("Avaliacao")]
[Index("IdAluno", "IdLivro", Name = "UQ_Avaliacao", IsUnique = true)]
public partial class Avaliacao
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nota")]
    public int Nota { get; set; }

    [Column("comentario")]
    [StringLength(300)]
    [Unicode(false)]
    public string? Comentario { get; set; }

    [Column("dataAvaliacao")]
    public DateOnly DataAvaliacao { get; set; }

    [Column("idAluno")]
    public int IdAluno { get; set; }

    [Column("idLivro")]
    public int IdLivro { get; set; }

    [ForeignKey("IdAluno")]
    [InverseProperty("Avaliacaos")]
    public virtual Aluno IdAlunoNavigation { get; set; } = null!;

    [ForeignKey("IdLivro")]
    [InverseProperty("Avaliacaos")]
    public virtual Livro IdLivroNavigation { get; set; } = null!;
}
