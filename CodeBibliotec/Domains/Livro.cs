using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Domains;

[Table("Livro")]
public partial class Livro
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    [StringLength(150)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Column("autor")]
    [StringLength(100)]
    [Unicode(false)]
    public string Autor { get; set; } = null!;

    [Column("anoPublicacao")]
    public int AnoPublicacao { get; set; }

    [Column("status")]
    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [InverseProperty("IdLivroNavigation")]
    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    [InverseProperty("IdLivroNavigation")]
    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    [InverseProperty("IdLivroNavigation")]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    [ForeignKey("IdLivro")]
    [InverseProperty("IdLivros")]
    public virtual ICollection<Categorium> IdCategoria { get; set; } = new List<Categorium>();
}
