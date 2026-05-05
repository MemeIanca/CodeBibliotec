
using CodeBibliotec.Interfaces;
using CodeBibliotec.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBibliotec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _LivroService;

        public LivroController(ILivroService livroService)
        {
            _LivroService = livroService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodosLivros()  // defina para encontrar o resultado de uma ação
        {
            try
            {
                var livros = await _LivroService.ObterTodosLivrosAsync(); // depositar os livros que a camada de servico vai depositar aqui
                return Ok(livros); // retorna o resultado da consulta
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao listar livros", erro = ex.Message }); // retorna o status code 500 e a mensagem de erro
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLivroPorId(int id)
        {
            try
            {
                var livro = await _LivroService.ObterLivroPorIdAsync(id);
                if (livro == null)

                    return NotFound(new { mensagem = "Livro não encontrado" });

                return Ok(livro);

                // {} essas chaves não são necessárias quando há apenas uma linha, mas se tiver mais que uma linha, coloca as chaves!
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao obter livro", erro = ex.Message });
            }

        }


        [HttpPost("cadastrar")] //metodo utilizado para fazer escrita de dados
        public async Task<IActionResult> Cadastrarlivro(LivroViewModel livroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var livro = await _LivroService.CadastrarLivroAsync(livroViewModel);
                return CreatedAtAction(nameof(ObterLivroPorId), new { id = livro.Id }, livro); // retorna o status code 201 e o livro cadastrado

            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message }); // retorna o status code 400 e a mensagem de erro 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao cadastrar o livro", erro = ex.Message });
            }

        }

        [HttpPut("{id}")] // método utilizado para atualizar um recurso existente
        public async Task<IActionResult> AtualizarLivro(int id, LivroViewModel livroViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = await _LivroService.AtualizaLivroAsync(id, livroViewModel);

                if (!resultado)
                    return NotFound(new { mensagem = "Livro não encontrado" }); 

                return Ok(new { mensagem = "Livro atualizado com sucesso" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message }); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao atualizar livro", ex.Message }); 
            }



        }


        [HttpDelete("{id}")] // método utilizado para deletar um recurso
        public async Task<IActionResult> DeletarLivro(int id)
        {
            try
            {
                var resultado = await _LivroService.DeletarLivroAsync(id);

                // aqui poderia ser (resultado !== true)
                if(!resultado) // se o resultado for falso, ou seja, o livro não foi encontrado para deletar, ! significa que ele é diferente de verdadeiro
                    return NotFound(new { mensagem = "Livro não foi encontrado" });

                return Ok(new { mensagem = "Livro deletado com sucesso" }); 

            }
            catch (Exception ex) 
            {
                return StatusCode(500, new { mensagem = "Erro ao deletar livro", erro = ex.Message });
            }



        }

    }                   
}
