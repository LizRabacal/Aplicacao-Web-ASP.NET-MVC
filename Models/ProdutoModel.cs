using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRABALHOELETROPONTO.Models
{
    public class Produto
    {
        [Key]
        public int ID_PRODUTO { get; set; }
        public string NOME_PRODUTO { get; set; }
        public string DESCRICAO { get; set; }
        public float? PRECO { get; set; }
        public int? ESTOQUE { get; set; }
    }
}