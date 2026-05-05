using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using CodeBibliotec.Repositories;
using CodeBibliotec.ViewModels;

namespace CodeBibliotec.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _CategoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _CategoriaRepository = categoriaRepository;
        }

        // Métodos para gerenciar categorias
        public async Task<List<CategoriumResponseDto>> ObterTodasCategoriasAsync()
        {
            var categorias = await _CategoriaRepository.ObterTodasCategoriasAsync();
            return categorias.Select(MapToCategoriumResponseDto).ToList(); // mapeando para categoria response Dto
        }

        public async Task<CategoriumResponseDto> ObterCategoriaPorIdAsync(int id)
        {
            var categoria = await _CategoriaRepository.ObterCategoriaPorIdAsync(id);
            return MapToCategoriumResponseDto(categoria);
        }


        // implementação do método para cadastrar uma nova categoria
        public async Task<CategoriumResponseDto> CadastrarCategoriaAsync(CategoriumViewModel categoria)
        {
            var cat = new Categorium
            {
                Nome = categoria.Nome,
            };

            var categoriaCadastrada = await _CategoriaRepository.CadastrarCategoriaAsync(cat);
            return MapToCategoriumResponseDto(categoriaCadastrada);
        }


       // //para deletar uma categoria existente
       // public async Task<bool> DeletarCategoriaAsync(int id)
       // {
       //     return await _CategoriaRepository.DeletarCategoriaAsync(id);

       // }


       //// para atualizar uma categoria existente
       // public async Task<bool> AtualizarCategoriaAsync(int id, CategoriumViewModel categoria)
       // {
       //     var categoriaExistente = await _CategoriaRepository.ObterCategoriaPorIdAsync(id);
       //     if (categoriaExistente == null) // Verifica se a categoria existe antes de atualizar
       //         return false; // ai retorna false para falar que não existe a categoria para atualizar.
       //     categoriaExistente.Nome = categoria.Nome; // Atualiza o nome da categoria
       //     await _CategoriaRepository.AtualizarCategoriaAsync(id, categoriaExistente);
       //     return true;
       // }

        private CategoriumResponseDto MapToCategoriumResponseDto(Categorium categoria)
        {
            if (categoria == null)
                return null!;  //!= diferente 

            return new CategoriumResponseDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
            };
        }
    }
}
