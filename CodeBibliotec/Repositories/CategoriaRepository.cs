using CodeBibliotec.Context;
using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using CodeBibliotec.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        // Método Construtor é usado para injetar a camada de contexto no repositório / repository
        private readonly BibliotecContext _context;
        public CategoriaRepository(BibliotecContext context)
        {
            _context = context;
        }



        // Método para obter todas as categorias

        public async Task<List<Categorium>> ObterTodasCategoriasAsync()
        {
            return await _context.Categoria.ToListAsync(); // Retorna a lista de categorias do banco de dados
        }



        //  Método para obter uma categoria por id
        public async Task<Categorium> ObterCategoriaPorIdAsync(int id)
        {
            return await _context.Categoria.FirstOrDefaultAsync(c => c.Id == id); // Retorna a categoria encontrada ou null se não for encontrada
        }




        //  Método para cadastrar uma nova categoria
        public async Task<Categorium> CadastrarCategoriaAsync(Categorium categoria)
        {
            var novaCategoria = new Categorium
            {
                Nome = categoria.Nome,
                //IdLivros = categoria.IdLivros != null ? categoria.IdLivros.Select(id => new Livro { Id = id }).ToList() : new List<Livro>() // Mapeia os IDs dos livros para a nova categoria
            };
            _context.Categoria.Add(novaCategoria); // Adiciona a nova categoria ao contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            return novaCategoria; // Retorna a categoria cadastrada
        }


        //Método para deletar uma categoria existente
        //public async Task<bool> DeletarCategoriaAsync(int id)
        //{
        //    var categoria = await _context.Categoria.FirstOrDefaultAsync(c => c.Id == id); // Busca a categoria pelo id
        //    if (categoria == null) // Se a categoria não for encontrada, retorna false
        //        return false;
        //    _context.Categoria.Remove(categoria); // Remove a categoria 
        //    await _context.SaveChangesAsync(); // Salva as alterações 
        //    return true; // Retorna true indicando que a categoria foi deletada com sucesso

        //}


        //// Método para atualizar uma categoria existente
        //public async Task<Categorium> AtualizarCategoriaAsync(int id, Categorium categoria)
        //{
        //    _context.Categoria.Update(categoria); // Atualiza a categoria 
        //    await _context.SaveChangesAsync();
        //    return categoria; // Retorna a categoria atualizada
        //}

        //Task<bool> ICategoriaRepository.AtualizarCategoriaAsync(int id, Categorium categoria)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
