using System;
using System.Collections.Generic;
using System.Text;
using Loans.Domain;

namespace Emprestimos.Dominio.Aplicacao
{
    public class ComparacaoMensalDeEmprestimo : ObjetoValor
    {
       

        public string NomeProduto { get; }
        public decimal TaxaJuros { get; }
        public decimal PagamentoMensal { get; }

        public ComparacaoMensalDeEmprestimo() {}


        public ComparacaoMensalDeEmprestimo(string nomeProduto, decimal taxaJuros, decimal pagamentoMensal)
        {
            NomeProduto = nomeProduto;
            TaxaJuros = taxaJuros;
            PagamentoMensal = pagamentoMensal;
        }

        protected override IEnumerable<object> ObterValoresAtomicos()
        {
            yield return NomeProduto;
            yield return TaxaJuros;
            yield return PagamentoMensal;
        }
    }
}
