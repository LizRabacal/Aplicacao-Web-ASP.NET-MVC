using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRABALHOELETROPONTO.Data;
using TRABALHOELETROPONTO.Models;

namespace TRABALHOELETROPONTO.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private readonly FuncionarioContext _Funcionariocontext;
        public FuncionarioRepository(FuncionarioContext Funcionariocontext)
        {
            _Funcionariocontext = Funcionariocontext;
        }

        public Funcionario Cadastrar(Funcionario Funcionario)
        {
            _Funcionariocontext.Funcionario.Add(Funcionario);
            _Funcionariocontext.SaveChanges();
            return Funcionario;


        }

        

    
        public List<Funcionario> ListarFuncionarios()
        {
            return _Funcionariocontext.Funcionario.ToList();
        }
     

      
    }
}