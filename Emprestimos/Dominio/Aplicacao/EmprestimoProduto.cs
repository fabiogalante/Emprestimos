namespace Emprestimos.Dominio.Aplicacao
{
    public sealed class EmprestimoProduto : Entidade
    {
        private readonly string _nomeProduto;
        private readonly decimal _taxaJuros;

        public EmprestimoProduto(int id, string nomeProduto, decimal taxaJuros)
        {
            Id = id;
            _nomeProduto = nomeProduto;
            _taxaJuros = taxaJuros;
        }


        public string ObterNomeProduto()
        {
            return _nomeProduto;
        }

        public decimal ObterTaxaJuros()
        {
            return _taxaJuros;
        }
    }
}
