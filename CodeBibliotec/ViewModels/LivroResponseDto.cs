namespace CodeBibliotec.ViewModels
{
    public class LivroResponseDto
    {
        public int Id { get; set; }
        public string titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string Status { get; set; }
        public List<CategoriaNomeDto> IdCategoria { get; set; } = new List<CategoriaNomeDto>();
    }
}
