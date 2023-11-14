using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabalhoWEBMVC3.Models
{
    [Table("Tonners")]
    public class Tonner
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Descricao é obrigatório...")]
        [StringLength(35)]
        [Display(Name = "Descricao")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo Valor é obrigatório.")]
        [Display(Name = "Valor")]
        public double valor { get; set; }

        [Required(ErrorMessage = "Campo Quantidades é obrigatório.")]
        [Display(Name = "Quantidades")]
        public int quantidade { get; set; }
    }
}
