using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRABALHOELETROPONTO.Models
{
    public class ItensVenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que o ID_ITEM é autoincrementado
        public int ID_ITEM { get; set; }

        public int ID_PRODUTO { get; set; }

        [Required]
        public int QUANTIDADE { get; set; }

        public string ID_CLIENTE { get; set; }

        [Required]
        public float SUBTOTAL { get; set; }

        public int? ID_VENDA { get; set; }


        // Relacionamentos

    }
}
