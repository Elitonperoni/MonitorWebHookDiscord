using APIProducao.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIProducao.DTO
{
    public class ProdutoDTO
    {
        public int id { get; set; }
        public int categoriaid { get; set; }
        public string? nome { get; set; }
        public string? descricao { get; set; }        
        public double preco { get; set; }
        public string? imagemurl { get; set; }        
        public DateTime datacadastro { get; set; }                
    }
}
