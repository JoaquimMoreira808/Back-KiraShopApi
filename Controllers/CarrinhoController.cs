using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KiraShopApi.Models;
using KiraShopApi.Dtos.Carrinho;
using KiraShopApi.Dtos.Produto;
using KiraApi2;

namespace KiraShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly KiraApiDbContext _context;

        public CarrinhoController(KiraApiDbContext context)
        {
            _context = context;
        }

        // GET: api/carrinho/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCarrinhoDto>> GetCarrinho(int id)
        {
            var carrinho = await _context.Carrinhos
                .Include(c => c.Usuario)
                .Include(c => c.Produtos)
                    .ThenInclude(p => p.Marca)
                .Include(c => c.Produtos)
                    .ThenInclude(p => p.Categorias)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (carrinho == null)
                return NotFound();

            var dto = new ReadCarrinhoDto
            {
                Id = carrinho.Id,
                UsuarioId = carrinho.UsuarioId,
                UsuarioNome = carrinho.Usuario.Nome,
                Produtos = carrinho.Produtos.Select(p => new ReadProdutoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    Descricao = p.Descricao,
                    MarcaId = p.MarcaId,
                    CategoriaIds = p.Categorias.Select(c => c.Id).ToList()
                }).ToList()
            };

            return Ok(dto);
        }

        // POST: api/carrinho
        // Cria um carrinho para um usuário (assume que só um carrinho por usuário)
        [HttpPost]
        public async Task<ActionResult<ReadCarrinhoDto>> CreateCarrinho(CreateCarrinhoDto createDto)
        {
            // Validação: verificar se usuário existe
            var usuario = await _context.Usuarios.FindAsync(createDto.UsuarioId);
            if (usuario == null)
                return BadRequest("Usuário não encontrado.");

            // Validação: garantir que o usuário não tenha carrinho já criado
            var carrinhoExistente = await _context.Carrinhos.FirstOrDefaultAsync(c => c.UsuarioId == createDto.UsuarioId);
            if (carrinhoExistente != null)
                return Conflict("Usuário já possui um carrinho.");

            var carrinho = new Carrinho
            {
                UsuarioId = createDto.UsuarioId,
                Produtos = new List<Produto>()
            };

            _context.Carrinhos.Add(carrinho);
            await _context.SaveChangesAsync();

            var readDto = new ReadCarrinhoDto
            {
                Id = carrinho.Id,
                UsuarioId = carrinho.UsuarioId,
                UsuarioNome = usuario.Nome,
                Produtos = new List<ReadProdutoDto>()
            };

            return CreatedAtAction(nameof(GetCarrinho), new { id = carrinho.Id }, readDto);
        }

        // PUT: api/carrinho/{id}
        // Atualiza os produtos do carrinho (substitui a lista atual pelos produtos indicados)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProdutosCarrinho(int id, UpdateCarrinhoDto updateDto)
        {
            var carrinho = await _context.Carrinhos
                .Include(c => c.Produtos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (carrinho == null)
                return NotFound();

            // Busca produtos válidos a partir dos IDs enviados
            var produtosValidos = await _context.Produtos
                .Where(p => updateDto.ProdutoIds.Contains(p.Id))
                .ToListAsync();

            // Validação: Verifica se todos os IDs existem
            if (produtosValidos.Count != updateDto.ProdutoIds.Count)
                return BadRequest("Um ou mais produtos não foram encontrados.");

            // Atualiza os produtos do carrinho - substitui a coleção
            carrinho.Produtos = produtosValidos;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/carrinho/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrinho(int id)
        {
            var carrinho = await _context.Carrinhos.FindAsync(id);
            if (carrinho == null)
                return NotFound();

            _context.Carrinhos.Remove(carrinho);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
