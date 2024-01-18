using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRABALHOELETROPONTO.Models
{
    public class vendaviewmodel
    {
  
    // Relacionamentos
    public virtual Venda Venda { get; set; }
    
    public virtual ItensVenda Produto { get; set; }
    }
}