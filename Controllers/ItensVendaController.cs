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
    public class ItensVendaController : Controller
    {
        private readonly ItensVendaContext _IVContext;
        private readonly UserManager<Cliente> _UserManager;

        private readonly ProdutoContext _Produto;
        public ItensVendaController(ItensVendaContext IVContext, ProdutoContext produto, UserManager<Cliente> UserManager)
        {
            _UserManager = UserManager;
            _Produto = produto;
            _IVContext = IVContext;


        }

        public IActionResult Carrinho(string idprocurado)
        {
            var itensVendaCliente = _IVContext.ItensVenda.Where(iv => iv.ID_CLIENTE == idprocurado).ToList();
            return View(itensVendaCliente);
        }
        [HttpPost]
        public IActionResult Carrinho(int ID_PRODUTO, string idcli, int QUANTIDADE, float PRECO)
        {
            // Verifica se o produto já está no carrinho
            var itemExistente = _IVContext.ItensVenda
                .FirstOrDefault(iv => iv.ID_PRODUTO == ID_PRODUTO && iv.ID_CLIENTE == idcli);

            if (itemExistente != null)
            {
                // Se o produto já estiver no carrinho, incrementa a quantidade e atualiza o subtotal
                itemExistente.QUANTIDADE += QUANTIDADE;
                itemExistente.SUBTOTAL = itemExistente.QUANTIDADE * PRECO;
            }
            else
            {
                // Se o produto não estiver no carrinho, adiciona uma nova entrada
                var ivenda = new ItensVenda
                {
                    ID_PRODUTO = ID_PRODUTO,
                    QUANTIDADE = QUANTIDADE,
                    SUBTOTAL = QUANTIDADE * PRECO,
                    ID_CLIENTE = idcli
                };
                _IVContext.ItensVenda.Add(ivenda);
            }

            _IVContext.SaveChanges();

            return RedirectToAction("Carrinho", new { idprocurado = idcli });
        }



        public IActionResult IncrementarQuantidade(int id)
        {
            var idcli = _UserManager.GetUserId(User);

            var itemExistente = _IVContext.ItensVenda.First(iv => iv.ID_PRODUTO == id && iv.ID_CLIENTE == idcli);


            if (itemExistente != null)
            {
                // Decrementa a quantidade (pode adicionar validação para garantir que a quantidade não seja menor que zero)
                itemExistente.QUANTIDADE = itemExistente.QUANTIDADE + 1;

                // Atualiza o subtotal

                // Remove o item se a quantidade se tornar zero
                if (itemExistente.QUANTIDADE == 0)
                {
                    _IVContext.ItensVenda.Remove(itemExistente);
                }

                _IVContext.SaveChanges();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            // Correção: Use o nome correto do parâmetro na ação "Carrinho" no redirecionamento
            return RedirectToAction("Carrinho", new { idprocurado = idcli });
        }


        public IActionResult DecrementarQuantidade(int id)
        {
            var idcli = _UserManager.GetUserId(User);

            var itemExistente = _IVContext.ItensVenda.First(iv => iv.ID_PRODUTO == id && iv.ID_CLIENTE == idcli);


            if (itemExistente != null)
            {
                // Decrementa a quantidade (pode adicionar validação para garantir que a quantidade não seja menor que zero)
                itemExistente.QUANTIDADE = itemExistente.QUANTIDADE - 1;

                // Atualiza o subtotal

                // Remove o item se a quantidade se tornar zero
                if (itemExistente.QUANTIDADE == 0)
                {
                    _IVContext.ItensVenda.Remove(itemExistente);
                }

                _IVContext.SaveChanges();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            // Correção: Use o nome correto do parâmetro na ação "Carrinho" no redirecionamento
            return RedirectToAction("Carrinho", new { idprocurado = idcli });
        }



        public IActionResult RemoverUm(int id)
        {
            var idcli = _UserManager.GetUserId(User);

            var itemExistente = _IVContext.ItensVenda.First(iv => iv.ID_PRODUTO == id && iv.ID_CLIENTE == idcli);
            if (itemExistente != null)
            {

                _IVContext.ItensVenda.Remove(itemExistente);
            }
            _IVContext.SaveChanges();

            return RedirectToAction("Carrinho", new { idprocurado = idcli });

        }


        public IActionResult RemoverTodos()
        {
            var idcli = _UserManager.GetUserId(User);

            var itensCliente = _IVContext.ItensVenda.Where(iv => iv.ID_CLIENTE == idcli).ToList();

            if (itensCliente.Any())
            {
                _IVContext.ItensVenda.RemoveRange(itensCliente);
                _IVContext.SaveChanges();
            }

            return RedirectToAction("Carrinho", new { idprocurado = idcli });
        }







    }
}