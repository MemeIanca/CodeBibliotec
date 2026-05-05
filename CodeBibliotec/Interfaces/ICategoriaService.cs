using CodeBibliotec.Domains;
using CodeBibliotec.ViewModels;

namespace CodeBibliotec.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriumResponseDto> CadastrarCategoriaAsync(CategoriumViewModel categoriaViewModel); 
        Task<List<CategoriumResponseDto>> ObterTodasCategoriasAsync(); 
        Task<CategoriumResponseDto> ObterCategoriaPorIdAsync(int id); 
    }
}
