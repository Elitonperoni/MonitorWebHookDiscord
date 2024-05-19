using APIProducao.Context;
using APIProducao.DTO;
using APIProducao.Models;
using APIProducao.Pagination;
using APIProducao.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace APIProducao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public CategoriasController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;            
            _mapper = mapper;            
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaDTO>> Get()
        {
            var categorias = await _uof.CategoriaRepository.Get().ToListAsync();
            var categoriaDto = _mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriaDto;
        }

        [HttpGet("produtos")]
        public async Task<IEnumerable<CategoriaDTO>> GetCategoriasProduto([FromQuery] CategoriasParameters categoriasParameters)
        {            
            var categorias = await _uof.CategoriaRepository.GetCategoriasPorProdutos(categoriasParameters);

            var metaData = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevius
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            var categoriaDto = _mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriaDto;
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<CategoriaDTO> GetById(int id)
        {
            var categoria = await _uof.CategoriaRepository.GetById(p => p.id.Equals(id));
            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return categoriaDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }

           _uof.CategoriaRepository.Add(categoria);
           await _uof.Commit();

           var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);

           return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.id }, categoriaDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CategoriaDTO categoriaDto)
        {            
            if (!id.Equals(categoriaDto.id))
            {
                return BadRequest();
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _uof.CategoriaRepository.Update(categoria) ;
            await _uof.Commit();
            
            return Ok(categoriaDto);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _uof.CategoriaRepository.GetById(p => p.id.Equals(id));

            if (categoria is null)
            {
                return NotFound("Categoria não localizado");
            }

            _uof.CategoriaRepository.Delete(categoria);
            await _uof.Commit();

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return Ok(categoriaDto);
        }
    }
}
