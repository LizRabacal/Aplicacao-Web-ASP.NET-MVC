using System.ComponentModel.DataAnnotations;

namespace TRABALHOELETROPONTO.Models;

public class LoginViewModel
{

    [Required (ErrorMessage = "O email é obrigatótio")]
    [EmailAddress(ErrorMessage = "Email inválido")]

    public string? Email { get; set; }

    [Required  (ErrorMessage = "A senha é obrigatótia")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }


    [Display(Name = "Lembrar-me")]
    public bool RememberMe { get; set; }


}