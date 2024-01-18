using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TRABALHOELETROPONTO.Models;
using TRABALHOELETROPONTO.Repository;
namespace TRABALHOELETROPONTO.Controllers;

public class HomeController : Controller
{

    private readonly IProdutosRepository _repositorio;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IProdutosRepository repositorio)
    {
        _repositorio = repositorio;
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Produto> produtos = _repositorio.ListarProdutos();
        return View(produtos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
