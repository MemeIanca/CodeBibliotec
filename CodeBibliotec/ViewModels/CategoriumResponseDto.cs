namespace CodeBibliotec.ViewModels
{
    public class CategoriumResponseDto // DTO para resposta de categoria, contendo o ID e o nome da categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<string> IdLivros { get; set; } = new List<string>(); // lista de IDs dos livros associados a essa categoria

    }
}
