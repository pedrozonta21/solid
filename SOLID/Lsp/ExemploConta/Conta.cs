namespace SOLID.Lsp.ExemploConta
{
    public abstract class Conta
    {
        public decimal ValorEmConta { get; protected set; }

        public abstract void RetirarDinheiro(decimal valor);

        public decimal RetornarQuantoDinheiroPossuiNaConta() => ValorEmConta;
    }
}
