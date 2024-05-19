using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIProducao.Models
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        public int id { get; set; }
        public int categoriaid { get; set; }

        [Required]
        [StringLength(80)]
        public string? nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? descricao { get; set; }

        [Required]
        [Column(TypeName = "numeric(15,5)")]
        public double preco  { get; set; }

        [Required]
        [StringLength(300)]
        public string? imagemurl { get; set; }
        public double estoque { get; set; }
        public DateTime datacadastro { get; set; }

        [JsonIgnore]
        public Categoria? Categorias { get; set; }
    }
}
