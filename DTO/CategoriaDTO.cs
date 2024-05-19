namespace APIProducao.DTO
{
    public class CategoriaDTO
    {
        public int id { get; set; }
        public string? nome { get; set; }
        public string? imagemurl { get; set; }
        public ICollection<ProdutoDTO> Produtos { get; set; }
    }
}
