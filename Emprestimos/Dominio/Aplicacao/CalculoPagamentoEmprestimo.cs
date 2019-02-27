using System;

namespace Emprestimos.Dominio.Aplicacao
{
    public class CalculoPagamentoEmprestimo
    {
        public decimal CalculoMensalDePagamento(
            ValorEmprestimo valor, 
            decimal taxaJurosAnual, 
            PrazoEmprestimo prazoEmprestimo)
        {
            var monthly = (double)taxaJurosAnual / 100 / 12 * (double)valor.EmprestimoValor / (1 - Math.Pow(1 + ((double)taxaJurosAnual / 100 / 12), -prazoEmprestimo.TotalMeses()));

            return new decimal(Math.Round(monthly, 2, MidpointRounding.AwayFromZero));
        }
    }
}
