using APIProducao.Context;
using APIProducao.DTO;
using APIProducao.Models;
using APIProducao.Pagination;
using APIProducao.Repository.Interfaces;
using APIWebHookDiscord.Notification;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace APIProducao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public ProdutosController(IUnitOfWork context, IMapper mapper)
        { 
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet("menorpreco")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutosPrecos()
        {
           var produtos = await _uof.ProdutoRepository.GetProdutosPorPreco();
           var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);
           return produtosDto;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get([FromQuery] ProdutosParameters produtosParameters)
        {
            var produtos = await _uof.ProdutoRepository.GetProdutos(produtosParameters);

            var metaData = new
            {
                produtos.TotalCount,
                produtos.PageSize,
                produtos.CurrentPage,
                produtos.TotalPages,
                produtos.HasNext,
                produtos.HasPrevius
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            var produtosDto = _mapper.Map<List<ProdutoDTO>>(produtos);
            return produtosDto;
        }

        [HttpGet("{id:int}", Name ="ObterProduto")]
        public async Task<ActionResult<ProdutoDTO>> GetById(int id)
        {
            var produto = await _uof.ProdutoRepository.GetById(p => p.id.Equals(id));

            if (produto is null)
            {
                return NotFound();
            }

            var produtoDTo = _mapper.Map<ProdutoDTO>(produto);
            return produtoDTo;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);

            if (produto is null)
            {
                return BadRequest();
            }

            try
            {                              
                _uof.ProdutoRepository.Add(produto);
                await _uof.Commit();              
            }
            catch (Exception ex)
            {
                await DiscordNotification.EnviarNotificacaoDiscord(DiscordServers.ServerLogs, "Ocorreu um erro ao gravar o produto: " + ex.InnerException.Message);
                return BadRequest();
            }

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);
            string mensagem = $"Produto gravado com sucesso em {DateTime.Now}\n + {JsonSerializer.Serialize(produtoDTO)}";
            await DiscordNotification.EnviarNotificacaoDiscord(DiscordServers.ServerLogs, mensagem);

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.id}, produtoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, ProdutoDTO produtoDto)
        {
            if (!id.Equals(produtoDto.id))
            {
                return BadRequest();
            }

            var produto = _mapper.Map<Produto>(produtoDto);

            _uof.ProdutoRepository.Update(produto);
            await _uof.Commit();

            return Ok(produtoDto);
        }

        [HttpDelete]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produto = await _uof.ProdutoRepository.GetById(p => p.id.Equals(id));

            if (produto is null)
            {
                return NotFound("Produto não localizado");
            }

            _uof.ProdutoRepository.Delete(produto);
            await _uof.Commit();

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return Ok(produtoDTO);
        }
    }
}
