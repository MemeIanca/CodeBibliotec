using CodeBibliotec.Domains;
using CodeBibliotec.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeBibliotec.Controllers
{

    [Route("api/[controller]")] // define a rota para o controller, ou seja, api/categoria
    [ApiController] // define que é um controller de API
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _CategoriaRepository; // injeção de dependência para o repositório de categoria

        public CategoriaController(ICategoriaRepository CategoriaRepository)
        {
            _CategoriaRepository = CategoriaRepository; // para receber a instância do repositório de categoria
        }



        [HttpGet]
        public async Task<IActionResult> ObterTodasCategorias()
        {
            var categorias = await _CategoriaRepository.ObterTodasCategoriasAsync();
            return Ok(categorias);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCategoriaPorId(int id)
        {
            var categoria = await _CategoriaRepository.ObterCategoriaPorIdAsync(id); // para obter a categoria por id
            if (categoria == null) // se a categoria for nula, ou seja, não for encontrada
            {
                return NotFound(new { mensagem = "Categoria não encontrada." }); // se a categoria não for encontrada, vai retornar a mensagem
            }
            return Ok(categoria); // se a categoria for encontrada, vai retornar a categoria
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarCategoria(Categorium categoria)
        {
            await _CategoriaRepository.CadastrarCategoriaAsync(categoria); // para cadastrar a categoria
            return Ok(new { mensagem = "Categoria cadastrada com sucesso." }); // se a categoria for cadastrada com sucesso, vai retornar a mensagem
        }



        //[HttpPut("{id}")]

        //public async Task<IActionResult> AtualizarCategoria(int id, Categorium categoria)
        //{
        //    var resultado = await _CategoriaRepository.
        //        AtualizarCategoriaAsync(id, categoria); // para atualizar a categoria
        //    if (!resultado) // se o resultado for falso, ou seja, a categoria não foi encontrada para atualizar
        //    {
        //        return NotFound(new { mensagem = "Categoria não encontrada." }); // se a categoria não for encontrada
        //    }
        //    return Ok(new { mensagem = "Categoria atualizada com sucesso." }); // se a categoria for atualizada com sucesso
        //}



        //[HttpDelete("{id}")]

        //public async Task<IActionResult> DeletarCategoria(int id)
        //{
        //    var resultado = await _CategoriaRepository.DeletarCategoriaAsync(id); // para deletar a categoria
        //    if (!resultado) // se o resultado for falso, ou seja, a categoria não foi encontrada para deletar
        //    {
        //        return NotFound(new { mensagem = "Categoria não encontrada." }); // se a categoria não for encontrada
        //    }
        //    return Ok(new { mensagem = "Categoria deletada com sucesso." }); // se a categoria for deletada com sucesso
        //}
    } 
}
