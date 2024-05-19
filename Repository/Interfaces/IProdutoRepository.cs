using APIProducao.Models;
using APIProducao.Pagination;

namespace APIProducao.Repository.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<PagedList<Produto>> GetProdutos(ProdutosParameters produtosParameters);
        Task<IEnumerable<Produto>> GetProdutosPorPreco();
    }
}
