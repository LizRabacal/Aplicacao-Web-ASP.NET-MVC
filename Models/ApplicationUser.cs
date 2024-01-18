using Microsoft.AspNetCore.Identity;
using System;
namespace TRABALHOELETROPONTO.Models;

public class ApplicationUser : IdentityUser
{
    public string NomeCompleto { get; set; }
    public DateTime DataNascimento { get; set; }

    public Cliente Cliente { get; set; }
}
