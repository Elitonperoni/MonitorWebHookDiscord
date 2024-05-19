using APIProducao.Context;
using APIProducao.Context;
using APIProducao.Models;
using APIProducao.Pagination;
using APIProducao.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIProducao.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext contexto) : base(contexto)
        {
                
        }
        public async Task<PagedList<Categoria>> GetCategorias(CategoriasParameters categoriasParameters)
        {
            return await PagedList<Categoria>.ToPagedList(Get().OrderBy(on => on.nome),
                        categoriasParameters.PageNumber,
                        categoriasParameters.PageSize);
        }

        public async Task<PagedList<Categoria>> GetCategoriasPorProdutos(CategoriasParameters categoriasParameters)
        {
            return await PagedList<Categoria>.ToPagedList(Get().Include(x => x.Produtos),
                        categoriasParameters.PageNumber,
                        categoriasParameters.PageSize);
        }
    }
}
