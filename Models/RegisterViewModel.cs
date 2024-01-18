using System.ComponentModel.DataAnnotations;

namespace TRABALHOELETROPONTO.Models;

public class RegisterViewModel
{

    [Required]
    [EmailAddress]

    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
        [Display(Name = "Senha")]

    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirme a senha")]

    [Compare("Password", ErrorMessage = "As senhas devem ser compatíveis")]
    public string? ConfirmPassword { get; set; }

     public string Nome { get; set; }

        public string Telefone { get; set; }

            public string Endereco { get; set; }




}