using System.ComponentModel.DataAnnotations;

namespace CodeBibliotec.ViewModels
{
    public class CategoriumViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Nome não pode exceder 50 caracteres.")]
        public string Nome { get; set; }
        public IEnumerable<int> IdLivros { get; internal set; }
    }
}
