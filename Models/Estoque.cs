using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabalhoWEBMVC3.Models
{
    [Table("Estoques")]
    public class Estoque
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Tonners")]
        public int tonnersID { get; set; }
        [ForeignKey("tonnersID")]
        public Tonner tonners { get; set; }

        [Required(ErrorMessage = "Campo Quantidades é obrigatório.")]
        [Display(Name = "Quantidades")]
        public int quantidade { get; set; }
    }
}
