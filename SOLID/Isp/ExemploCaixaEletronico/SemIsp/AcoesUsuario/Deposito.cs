using System;

namespace SOLID.Isp.ExemploCaixaEletronico.SemIsp.AcoesUsuario
{
    public class Deposito : Transacao, IInterfaceUsuario
    {
        public override void RealizarTransacao() => Console.Write("Transação para depósito");

        public void SolicitarQuantiaParaDeposito() => Console.Write("Digite a quantia a depositar");

        public void SolocitarQuantiaParaSaque() { /*Depósito não tem saque*/ }

        public void SolocitarQuantiaParaTransferencia() { /*Depósito não tem transferência*/ }

        public void InformarSaldoInsuficiente() { /*Depósito não tem saldo insuficiente*/ }
    }
}
