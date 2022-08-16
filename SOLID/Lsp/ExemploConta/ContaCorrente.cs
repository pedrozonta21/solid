using System;

namespace SOLID.Lsp.ExemploConta
{
    public class ContaCorrente : Conta
    {
        public decimal LimiteCartaoDeCredito { get; set; }
        public decimal QuantiaRestanteDoLimite { get; set; }

        public override void RetirarDinheiro(decimal valor) => ValorEmConta -= valor;

        public void PagarComCartaoDeCredito(decimal valor)
        {
            if(QuantiaRestanteDoLimite - valor < 0) throw new Exception("Limite insuficiente");
            QuantiaRestanteDoLimite -= valor;
            RetirarDinheiro(valor);
        }
    }
}
