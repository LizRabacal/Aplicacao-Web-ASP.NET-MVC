using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRABALHOELETROPONTO.Models
{
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_VENDA { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DATA_VENDA { get; set; }

        public string ID_CLIENTE { get; set; }

        public float DESCONTO { get; set; }

        public float TOTAL { get; set; }

        public bool? PAGAMENTO_EFETUADO { get; set; } = false; // Adicionado campo de pagamento efetuado

        // Relacionamentos
    }
}
