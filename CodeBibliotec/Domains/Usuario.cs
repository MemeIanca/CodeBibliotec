using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Domains;

[Table("Usuario")]
[Index("Email", Name = "UQ__Usuario__AB6E61649C2607FD", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("senha")]
    [StringLength(255)]
    [Unicode(false)]
    public string Senha { get; set; } = null!;

    [InverseProperty("IdUsuarioNavigation")]
    public virtual Aluno? Aluno { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual Bibliotecarium? Bibliotecarium { get; set; }
}
