using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRABALHOELETROPONTO.Models
{
    public class Funcionario
    {
        [Key]
        public int ID_FUNC { get; set; }
        public string NOME_FUNC { get; set; }
        public string CARGO { get; set; }
        public float? SALARIO { get; set; }
        public DateTime? DATA_ADMISSAO { get; set; }
        public string TELEFONE { get; set; }


    }
}