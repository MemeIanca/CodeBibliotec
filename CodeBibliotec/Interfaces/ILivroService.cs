using CodeBibliotec.Domains;
using CodeBibliotec.ViewModels;

namespace CodeBibliotec.Interfaces
{
    public interface ILivroService
    {
        Task<LivroResponseDto> CadastrarLivroAsync(LivroViewModel LivroViewModel);
        Task<LivroResponseDto> ObterLivroPorIdAsync(int id);
        Task<List<LivroResponseDto>> ObterTodosLivrosAsync();
        Task<bool> AtualizaLivroAsync(int id, LivroViewModel livroViewModel);
        Task<bool> DeletarLivroAsync(int id);
    }
}
