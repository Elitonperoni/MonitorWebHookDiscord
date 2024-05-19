using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProducao.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string? nome { get; set; }

        [Required]
        [StringLength(50)]
        public string? senha { get; set; }
    }
}
