using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TRABALHOELETROPONTO.Repository;
using TRABALHOELETROPONTO.Models;
using TRABALHOELETROPONTO.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace TRABALHOELETROPONTO.Controllers
{



    public class ProdutoController : Controller
    {
        private readonly IProdutosRepository _repositorio;
        private readonly ProdutoContext _context;
        public ProdutoController(IProdutosRepository repositorio, ProdutoContext context)
        {
            _context = context;

            _repositorio = repositorio;

        }


    [Authorize]

        public IActionResult Cadastrar()
        {
            return View();
        }
    [Authorize]

        public IActionResult Listar()
        {

            return View(_repositorio.ListarProdutos());
        }
        public IActionResult Detalhes(int id)
        {
            Produto produto = _repositorio.EncontrarPorId(id);
            return View(produto);
        }



    [Authorize]

        [HttpPost]
        public IActionResult Cadastrar(Produto Produto)
        {
            _repositorio.Cadastrar(Produto);
            return RedirectToAction("Index", "Home");
        }

    [Authorize]

        public IActionResult Remover(int Id)
        {
            Produto produto = _repositorio.EncontrarPorId(Id);

            if (produto != null)
            {
                _repositorio.Remover(produto);

            }

            return RedirectToAction("Listar", "Produto");
        }





    [Authorize]


        public IActionResult Editar(int Id)
        {
            Produto produto = _repositorio.EncontrarPorId(Id);
            if (produto == null)
            {
                // Lide com o cenário em que o produto não foi encontrado, por exemplo, redirecione para uma página de erro.
                return NotFound();
            }

            return View(produto);
        }

    [Authorize]

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Editar(produto);
                return RedirectToAction("Listar", "Produto");
            }

            // Se houver erros de validação, retorne à view de edição com mensagens de erro
            return View(produto);
        }

    [Authorize]

        [HttpGet]
        public IActionResult BuscarProduto(string termoBusca)
        {
            string connectionString = "server=localhost; database=empresarabanete; user=admin; password=Regenere@123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta SQL para buscar o produto com base no termo de busca
                    string query = "SELECT NOME_PRODUTO, ID_PRODUTO, PRECO FROM TABELA_PRODUTOS WHERE NOME_PRODUTO LIKE @TermoBusca";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TermoBusca", "%" + termoBusca + "%");

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Se encontrar o produto, exibe as informações
                        string nomeProduto = reader["NOME_PRODUTO"].ToString();
                        int idProduto = Convert.ToInt32(reader["ID_PRODUTO"]);
                        decimal preco = Convert.ToDecimal(reader["PRECO"]);

                        ViewBag.NomeProduto = nomeProduto;
                        ViewBag.IdProduto = idProduto;
                        ViewBag.Preco = preco;

                        return View("BuscaProduto");
                    }
                    else
                    {
                        // Se não encontrar o produto, exibe uma mensagem na tela
                        ViewBag.Mensagem = "Produto não encontrado.";
                        return View("ProdutoNaoEncontrado");
                    }
                }
                catch (Exception ex)
                {
                    // Lidar com exceções, logar ou tratar conforme necessário
                    ViewBag.Mensagem = "Erro ao buscar produto: " + ex.Message;
                    return View("ProdutoNaoEncontrado");
                }
            }
        }




    }
}