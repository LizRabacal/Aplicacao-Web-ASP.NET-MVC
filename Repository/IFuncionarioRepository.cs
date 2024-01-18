using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRABALHOELETROPONTO.Models;

namespace TRABALHOELETROPONTO.Repository
{
    public interface IFuncionarioRepository
    {
        
        Funcionario Cadastrar(Funcionario Funcionario);
        List<Funcionario> ListarFuncionarios();
    }
}