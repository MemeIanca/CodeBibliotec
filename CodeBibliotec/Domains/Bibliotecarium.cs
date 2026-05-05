using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Domains;

[Index("RegistroFuncional", Name = "UQ__Bibliote__E71EE24768F66B30", IsUnique = true)]
public partial class Bibliotecarium
{
    [Key]
    [Column("idUsuario")]
    public int IdUsuario { get; set; }

    [Column("registroFuncional")]
    [StringLength(20)]
    [Unicode(false)]
    public string RegistroFuncional { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Bibliotecarium")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
