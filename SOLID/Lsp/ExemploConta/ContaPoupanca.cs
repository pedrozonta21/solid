namespace SOLID.Lsp.ExemploConta
{
    //ContaPoupanca não pode implementar Conta
    public class ContaPoupanca : Conta
    {
        public override void RetirarDinheiro(decimal valor)
        {
            if (ValorEmConta < valor) return;
            ValorEmConta -= valor;
        }
    }
}
