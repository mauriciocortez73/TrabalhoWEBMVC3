using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabalhoWEBMVC3.Models
{
    [Table("Impressoras")]
    public class Impressora
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Descricao é obrigatório...")]
        [StringLength(35)]
        [Display(Name = "Descricao")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo Patrimonio é obrigatório")]
        [Display(Name = "Patrimonio")]
        public int patrimonio { get; set; }

    }
}
