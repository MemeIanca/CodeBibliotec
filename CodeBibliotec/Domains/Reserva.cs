using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Domains;

[Table("Reserva")]
[Index("IdAluno", "IdLivro", "DataReserva", Name = "UQ_Reserva", IsUnique = true)]
public partial class Reserva
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("dataReserva")]
    public DateOnly DataReserva { get; set; }

    [Column("dataPrevistaDevolucao")]
    public DateOnly DataPrevistaDevolucao { get; set; }

    [Column("idAluno")]
    public int IdAluno { get; set; }

    [Column("idLivro")]
    public int IdLivro { get; set; }

    [ForeignKey("IdAluno")]
    [InverseProperty("Reservas")]
    public virtual Aluno IdAlunoNavigation { get; set; } = null!;

    [ForeignKey("IdLivro")]
    [InverseProperty("Reservas")]
    public virtual Livro IdLivroNavigation { get; set; } = null!;
}
