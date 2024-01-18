using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TRABALHOELETROPONTO.Repository;
using TRABALHOELETROPONTO.Models;
using Microsoft.AspNetCore.Authorization;
using TRABALHOELETROPONTO.Data;
using Microsoft.AspNetCore.Identity;

namespace TRABALHOELETROPONTO.Controllers
{

    [Authorize]
    public class VendaController : Controller
    {
        private readonly VendaContext _VendaContext;
        private readonly ItensVendaContext _IVendaContext;
        private readonly UserManager<Cliente> _UserManager;

        private readonly ProdutoContext _Produto;
        public VendaController(VendaContext IVContext, ProdutoContext produto, UserManager<Cliente> UserManager, ItensVendaContext IV)
        {
            _IVendaContext = IV;
            _UserManager = UserManager;
            _Produto = produto;
            _VendaContext = IVContext;


        }


        public IActionResult Pagamento(string idprocurado)
        {
            var itensVendaCliente = _IVendaContext.ItensVenda.Where(iv => iv.ID_CLIENTE == idprocurado).ToList();

        


            return View(itensVendaCliente);
        }
    }


}