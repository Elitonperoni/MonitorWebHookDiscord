using APIProducao.Models;
using APIProducao.Pagination;

namespace APIProducao.Repository.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<PagedList<Categoria>> GetCategoriasPorProdutos(CategoriasParameters categoriasParameters);
    }
}
