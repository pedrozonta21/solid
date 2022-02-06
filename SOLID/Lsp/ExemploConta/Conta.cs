namespace SOLID.Lsp.ExemploConta
{
    public abstract class Conta
    {
        public decimal ValorEmConta { get; set; }

        public virtual void RetirarDinheiro(decimal valor) => ValorEmConta -= valor;

        public decimal RetornarQuantoDinheiroPossuiNaConta() => ValorEmConta;
    }
}
