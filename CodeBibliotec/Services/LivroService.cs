using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using CodeBibliotec.Repositories;
using CodeBibliotec.ViewModels;

namespace CodeBibliotec.Services
{
    public class LivroService : ILivroService
    {

        private readonly ILivroRepository _LivroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _LivroRepository = livroRepository;
        }

        public async Task<bool> AtualizaLivroAsync(int id, LivroViewModel livroViewModel)
        {
            var livro = new Livro
            {
                Id = id,
                Titulo = livroViewModel.Titulo,
                Autor = livroViewModel.Autor,
                AnoPublicacao = livroViewModel.AnoPublicacao,

                Status = string.IsNullOrWhiteSpace(livroViewModel.Status)
                    ? "Disponivel" 
                    : livroViewModel.Status.Trim()
            };

            if (livroViewModel.CategoriaIds != null)
            {
                livro.IdCategoria = livroViewModel.CategoriaIds.Select( id => new Categorium { Id = id, Nome = string.Empty }).ToList();
            }

            return await _LivroRepository.AtualizarLivroAsync(id, livro);



        }

        public async Task<LivroResponseDto> CadastrarLivroAsync(LivroViewModel livroViewModel)
        {
            var livro = new Livro
            {
                Titulo = livroViewModel.Titulo,
                Autor = livroViewModel.Autor,
                AnoPublicacao = livroViewModel.AnoPublicacao,

                Status = string.IsNullOrWhiteSpace(livroViewModel.Status)
                ? "Disponivel"  // valor padrão se o status for nulo ou vazio
                : livroViewModel.Status.Trim(), // trim para remover espaços em branco
            };

            if (livroViewModel.CategoriaIds != null && livroViewModel.CategoriaIds.Any()) // any se tem algo na lista
            {
               livro.IdCategoria = livroViewModel.CategoriaIds.Select(id => new Categorium { Id = id, Nome = string.Empty}).ToList(); // mapeando a categoria para o livro

            }

            var response = await _LivroRepository.CadastrarLivroAsync(livro);

            return MapToLivroResponseDto(response);

        }

        public async Task<bool> DeletarLivroAsync(int id)
        {
           return await _LivroRepository.DeletarLivrosAsync(id); // receber o resultado do delete do repositório e retornar para a camada de serviço

        }

        public async Task<LivroResponseDto> ObterLivroPorIdAsync(int id)
        {
            var livro = await _LivroRepository.ObterLivroPorIdAsync(id);
            return MapToLivroResponseDto(livro); // mapeando para livro response Dto
        }

        public async Task<List<LivroResponseDto>> ObterTodosLivrosAsync()
        {
            var livros = await _LivroRepository.ObterTodosLivrosAsync();

            return livros.Select(MapToLivroResponseDto).ToList();   // mapei para livros response Dto
        }


        private LivroResponseDto MapToLivroResponseDto(Livro livro)
        {
            if (livro == null)
            {
                return null;
            }


            return new LivroResponseDto 
            { 
                Id = livro.Id, 
                titulo = livro.Titulo, 
                Autor = livro.Autor, 
                AnoPublicacao = livro.AnoPublicacao, 
                Status = livro.Status,
                IdCategoria = livro.IdCategoria.Select(c => new CategoriaNomeDto { Nome = c.Nome }).ToList(),
            }; // mapeando uma categoria em especifico na lista de categoria

        }


    }
}
