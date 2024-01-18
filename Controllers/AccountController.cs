using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TRABALHOELETROPONTO.Models;

namespace LOGINTESTE.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Cliente> userManeger;
        private readonly SignInManager<Cliente> signInManeger;

        public AccountController(UserManager<Cliente> userManeger, SignInManager<Cliente> signInManeger)
        {
            this.userManeger = userManeger;
            this.signInManeger = signInManeger;

        }


        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new Cliente
                {
                    UserName = model.Email,
                    Email = model.Email,
                    NOME_CLI  = model.Nome,
                    TELEFONE = model.Telefone,
                    ENDERECO = model.Endereco
                };

                var result = await userManeger.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManeger.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }


            }

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManeger.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false

                );

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login inválido");
            }

            return View(model);

        }

        [HttpPost]

        public async Task<IActionResult> Logout(LoginViewModel model)
        {
            await signInManeger.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}