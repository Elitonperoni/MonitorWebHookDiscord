namespace APIProducao.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        Task Commit();
    }
}
