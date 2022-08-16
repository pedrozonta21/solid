using System;

namespace SOLID.Lsp.ExemploConta
{
    public class ContaFake : Conta
    {
        public override void RetirarDinheiro(decimal valor)
        {
            throw new NotImplementedException();
        }
    }
}
