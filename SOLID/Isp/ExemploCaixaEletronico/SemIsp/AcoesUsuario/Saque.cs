using System;

namespace SOLID.Isp.ExemploCaixaEletronico.SemIsp.AcoesUsuario
{
    public class Saque : Transacao, IInterfaceUsuario
    {
        public override void RealizarTransacao() => Console.Write("Transação para saque");

        public void SolicitarQuantiaParaDeposito() { /*Saque não tem depósito*/ }

        public void SolocitarQuantiaParaSaque() => Console.Write("Digita a quantia a sacar");

        public void SolocitarQuantiaParaTransferencia() { /*Saque não tem tranferência*/ }

        public void InformarSaldoInsuficiente() => Console.Write("Saldo insuficiente");
    }
}
