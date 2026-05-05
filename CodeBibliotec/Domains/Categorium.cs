using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Domains;

[Index("Nome", Name = "UQ__Categori__6F71C0DC4245550D", IsUnique = true)]
public partial class Categorium
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [ForeignKey("IdCategoria")]
    [InverseProperty("IdCategoria")]
    public virtual ICollection<Livro> IdLivros { get; set; } = new List<Livro>();
}
