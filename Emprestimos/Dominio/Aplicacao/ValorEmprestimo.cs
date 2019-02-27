using System.Collections.Generic;
using Loans.Domain;

namespace Emprestimos.Dominio.Aplicacao 
{
    public class ValorEmprestimo : ObjetoValor
    {
        public string CodigoMoeda { get; set; }
        public decimal EmprestimoValor { get; set; }


        public ValorEmprestimo() {}

        public ValorEmprestimo(string codigoMoeda, decimal emprestimoValor)
        {
            CodigoMoeda = codigoMoeda;
            EmprestimoValor = emprestimoValor;
        }

        protected override IEnumerable<object> ObterValoresAtomicos()
        {
            yield return CodigoMoeda;
            yield return EmprestimoValor;
        }
    }
}
