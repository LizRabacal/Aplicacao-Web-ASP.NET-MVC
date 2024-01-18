using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TRABALHOELETROPONTO.Repository;
using TRABALHOELETROPONTO.Models;
using Microsoft.AspNetCore.Authorization;

namespace TRABALHOELETROPONTO.Controllers
{
[Authorize]
    public class ClienteController : Controller
    {
        



        public IActionResult Listar()
        {
            return View();
        }

 




    }
}