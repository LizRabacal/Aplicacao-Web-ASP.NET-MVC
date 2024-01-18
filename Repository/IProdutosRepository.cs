using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRABALHOELETROPONTO.Data;
using TRABALHOELETROPONTO.Models;

namespace TRABALHOELETROPONTO.Repository
{
    public interface IProdutosRepository
    {
     
        Produto Cadastrar(Produto Produto);
        Produto Editar(Produto Produto);
        Produto Remover(Produto Produto);
        Produto EncontrarPorId(int id);
        List<Produto> ListarProdutos();
    }
}