using System;

namespace SOLID.Isp.ExemploCaixaEletronico.SemIsp.AcoesUsuario
{
    public class Transferencia : Transacao, IInterfaceUsuario
    {
        public override void RealizarTransacao() => Console.Write("Transação para transaferência");

        public void SolicitarQuantiaParaDeposito() { /*Transferência não tem depósito*/ }

        public void SolocitarQuantiaParaSaque() { /*Transferência não tem saque*/ }

        public void SolocitarQuantiaParaTransferencia() { Console.Write("Digite a quantia a ser transferida"); }
        
        public void InformarSaldoInsuficiente() { Console.Write("Saldo insuficiente"); }
    }
}
