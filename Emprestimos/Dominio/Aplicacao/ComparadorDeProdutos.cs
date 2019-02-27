using System;
using System.Collections.Generic;
using System.Text;

namespace Emprestimos.Dominio.Aplicacao
{
    public class ComparadorDeProdutos
    {
        private readonly ValorEmprestimo _valorEmprestimo;
        private readonly List<EmprestimoProduto> _emprestimoProduto;

        public ComparadorDeProdutos(ValorEmprestimo valorEmprestimo, List<EmprestimoProduto> emprestimoProduto)
        {
            _valorEmprestimo = valorEmprestimo;
            _emprestimoProduto = emprestimoProduto;
        }



        public List<ComparacaoMensalDeEmprestimo> ComparacaoMensalDeReembolsos(PrazoEmprestimo prazoEmprestimo)
        {
            var calculo = new CalculoPagamentoEmprestimo();

            var comparador = new List<ComparacaoMensalDeEmprestimo>();

            foreach (var produto in _emprestimoProduto)
            {
                decimal reembolso =
                    calculo.CalculoMensalDePagamento(_valorEmprestimo, produto.ObterTaxaJuros(), prazoEmprestimo);
                comparador.Add(new ComparacaoMensalDeEmprestimo(produto.ObterNomeProduto(), produto.ObterTaxaJuros(), reembolso));

            }

            return comparador;

        }
    }
}
