namespace SOLID.Lsp.ExemploConta
{
    public class ContaPoupanca : Conta
    {
        public override void RetirarDinheiro(decimal valor)
        {
            if (ValorEmConta < valor) return;
            ValorEmConta -= valor;
        }
    }
}
