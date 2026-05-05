using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Domains;

[Table("Aluno")]
[Index("Matricula", Name = "UQ__Aluno__30962D159255B463", IsUnique = true)]
public partial class Aluno
{
    [Key]
    [Column("idUsuario")]
    public int IdUsuario { get; set; }

    [Column("matricula")]
    [StringLength(20)]
    [Unicode(false)]
    public string Matricula { get; set; } = null!;

    [InverseProperty("IdAlunoNavigation")]
    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    [InverseProperty("IdAlunoNavigation")]
    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("Aluno")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [InverseProperty("IdAlunoNavigation")]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
