using CodeBibliotec.Context;
using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeBibliotec.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        // Método Construtor é usado para injetar a camada de contexto no repositório / repository
        private readonly BibliotecContext _context;

        public LivroRepository(BibliotecContext context)
        {
            _context = context;
        }

        public async Task<bool> AtualizarLivroAsync(int id, Livro livro)
        {
            var livroExistente = await _context.Livros
                .Include(l => l.IdCategoria)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (livroExistente == null)
                return false;

            livroExistente.Titulo = livro.Titulo;
            livroExistente.Autor = livro.Autor;
            livroExistente.AnoPublicacao = livro.AnoPublicacao;
            livroExistente.Status = livro.Status;

            if (livro.IdCategoria != null)
            {
                var CategoriaIds = livro.IdCategoria.Select(c => c.Id).ToList(); 

                var categorias = await _context.Categoria.Where(c => CategoriaIds.Contains(c.Id)).ToListAsync(); // busca as categorias do banco de dados que correspondem aos ids fornecidos

                livroExistente.IdCategoria.Clear(); // limpa as categorias existentes do livro

                foreach (var categoria in categorias)
                {
                    livroExistente.IdCategoria.Add(categoria); // adiciona as novas categorias ao livro
                }

            }

            _context.Livros.Update(livroExistente); // atualiza o livro no contexto

            await _context.SaveChangesAsync(); // salva as alterações no banco de dados

            return true;


        }



        public async Task<Livro> CadastrarLivroAsync(Livro Livro)
        {
            if (Livro.IdCategoria != null && Livro.IdCategoria.Any())  // se o id categoria é diferente de nulo
            {
                var categoriaIds = Livro.IdCategoria.Select(c => c.Id).ToList();

                Livro.IdCategoria = await _context.Categoria.Where(c => categoriaIds.Contains(c.Id)).ToListAsync(); // busca as categorias do banco de dados que correspondem aos ids fornecidos e atribui à propriedade IdCategoria do livro
            }
            _context.Livros.Add(Livro); // adiciona o livro ao contexto

            await _context.SaveChangesAsync(); // salva as alterações no banco de dados

            return Livro;
        }



        public async Task<bool> DeletarLivrosAsync(int id)
        {              // await para aguardar a conclusão da operação assíncrona de busca do livro por id
            var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == id); // busca o livro por id

            if (livro == null) // se o livro não for encontrado/ for igual a nulo, retorna falso
                return false;

            _context.Livros.Remove(livro); // remove o livro do contexto 
            await _context.SaveChangesAsync(); // salva as alterações no banco de dados 

            return true; // retorna verdadeiro indicando que o livro foi deletado com sucesso

        }



        public async Task<Livro> ObterLivroPorIdAsync(int id)
        {
            return await _context.Livros.Include(l => l.IdCategoria).FirstOrDefaultAsync(l => l.Id == id); // busca o livro por id e inclui a categoria relacionada
        }



        public async Task<List<Livro>> ObterTodosLivrosAsync()
        {
            return await _context.Livros.Include(l => l.IdCategoria).ToListAsync(); // coloca na lista de forma assíncrona
        }   // usa async / await sempre que for consultar os dados do banco


    }
}
