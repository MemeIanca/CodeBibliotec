using System.ComponentModel.DataAnnotations;

namespace CodeBibliotec.ViewModels
{
    public class LivroViewModel
    {
        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(150, ErrorMessage = "O título não pode exceder 150 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(100, ErrorMessage = "O título não pode exceder 100 caracteres")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O ano de pubicação é obrigatório")]
        [Range(0, 2026, ErrorMessage = "O ano deve ser válido")]
        public int AnoPublicacao { get; set; } = 0;

        [StringLength(20, ErrorMessage = "O Status não pode exceder 20 caracteres")]
        public string Status { get; set; }
        public List<int>? CategoriaIds { get; set; } = new List<int>();
    }
}
