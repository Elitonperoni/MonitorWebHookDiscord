using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIProducao.Models
{
    [Table("categoria")]
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();       
        }

        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(80)]
        public string? nome { get; set; }

        [Required]
        [MaxLength(300)]
        public string? imagemurl { get; set; }

        [JsonIgnore]
        public ICollection<Produto>? Produtos { get; set; }
    }
}
