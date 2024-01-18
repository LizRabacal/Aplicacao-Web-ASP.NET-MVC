using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRABALHOELETROPONTO.Data;
using TRABALHOELETROPONTO.Models;

namespace TRABALHOELETROPONTO.Repository
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly ProdutoContext _Produtocontext;
        public ProdutosRepository(ProdutoContext Funcionariocontext)
        {
            _Produtocontext = Funcionariocontext;
        }
        public Produto Cadastrar(Produto Produto)
        {
            _Produtocontext.Produto.Add(Produto);
            _Produtocontext.SaveChanges();
            return Produto;
        }

        public Produto Editar(Produto Produto)
        {
           _Produtocontext.Produto.Update(Produto);
            _Produtocontext.SaveChanges();
            return Produto;
        }

        public Produto EncontrarPorId(int id)
        {
            Produto produtoEncontrado = _Produtocontext.Produto.Find(id);
            return produtoEncontrado;
        }

        public List<Produto> ListarProdutos()
        {
            return _Produtocontext.Produto.ToList();
        }

        public Produto Remover(Produto Produto)
        {

          _Produtocontext.Produto.Remove(Produto);
            _Produtocontext.SaveChanges();
            return Produto;
        }
    }
}