using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TRABALHOELETROPONTO.Models
{
   public class Cliente : IdentityUser
{
    [Key]
    public int ID_CLIENTE { get; set; }

    public string NOME_CLI { get; set; }

    public string TELEFONE { get; set; }
    public string ENDERECO { get; set; }

   
}
}