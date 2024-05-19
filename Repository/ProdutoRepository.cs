using APIProducao.Context;
using APIProducao.Models;
using APIProducao.Pagination;
using APIProducao.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIProducao.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext contexto) : base(contexto)
        {
                
        }
        public async Task<PagedList<Produto>> GetProdutos(ProdutosParameters produtosParameters)
        {
            return await PagedList<Produto>.ToPagedList(Get().OrderBy(on => on.id),
                produtosParameters.PageNumber, produtosParameters.PageSize);
        }
        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await Get().OrderBy(c => c.preco).ToListAsync();
        }
        public async Task<IEnumerable<Produto>> GetProdutosPorPreco()
        {
            return await  Get().OrderBy(c => c.preco).ToListAsync();
        }     
    }
}
