namespace SOLID.Isp.ExemploCaixaEletronico.SemIsp
{
    public interface IInterfaceUsuario
    {
        void SolicitarQuantiaParaDeposito();
        void SolocitarQuantiaParaSaque();
        void SolocitarQuantiaParaTransferencia();
        void InformarSaldoInsuficiente();
    }
}
