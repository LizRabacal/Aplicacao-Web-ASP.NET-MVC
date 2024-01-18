using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TRABALHOELETROPONTO.Models;
using TRABALHOELETROPONTO.Repository;

namespace TRABALHOELETROPONTO.Controllers
{
    public class FuncionarioController : Controller
    {
         private readonly IFuncionarioRepository _repositorio;
        public FuncionarioController(IFuncionarioRepository repositorio)
        {

            _repositorio = repositorio;

        }

         public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View();
        }

         [HttpPost]
         public IActionResult Cadastrar(Funcionario func)
        {
            _repositorio.Cadastrar(func);
            return RedirectToAction("Index", "Home");
        }


        
    }
}