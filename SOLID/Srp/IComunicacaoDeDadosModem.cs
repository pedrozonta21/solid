namespace SOLID.Srp
{
    public interface IComunicacaoDeDadosModem
    {
        void EnviarComunicacao(string comunicacao);
        char ReceberComunicacao();
    }
}
