using System;
using System.Collections.Generic;
using Loans.Domain;

namespace Emprestimos.Dominio.Aplicacao
{
    public class PrazoEmprestimo : ObjetoValor
    {
        public int Anos { get; set; }


        public PrazoEmprestimo() {}


        public PrazoEmprestimo(int anos)
        {
            if (anos < 1)
                throw new ArgumentOutOfRangeException(nameof(anos), "Informe um valor maior que 0.");

            Anos = anos;
        }

        public int TotalMeses() => Anos * 12;

        protected override IEnumerable<object> ObterValoresAtomicos()
        {
            yield return Anos;
        }
    }
}
