using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabalhoWEBMVC3.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Impressoras")]
        public int impressorasID { get; set; }
        [ForeignKey("impressorasID")]
        public Impressora impressoras { get; set; }

        [Display(Name = "Tonners")]
        public int tonnersID { get; set; }
        [ForeignKey("tonnersID")]
        public Tonner tonners { get; set; }

        [Required(ErrorMessage = "Campo Quantidades é obrigatório.")]
        [Display(Name = "Quantidades")]
        public int quantidade { get; set; }

        [Display(Name = "Valor")]
        public double valor { get; set; }
    }
}
