using CodeBibliotec.Domains;

namespace CodeBibliotec.Interfaces
{
    public interface ICategoriaRepository
    {
       Task<Categorium>CadastrarCategoriaAsync(Categorium categoria); // método para cadastrar uma nova categoria
       Task<List<Categorium>> ObterTodasCategoriasAsync(); // método para obter todas as categorias
       Task<Categorium> ObterCategoriaPorIdAsync(int id); // método para obter uma categoria por id
        //Task<bool> DeletarCategoriaAsync(int id);
        //Task<bool> AtualizarCategoriaAsync(int id, Categorium categoria);
    }
}
