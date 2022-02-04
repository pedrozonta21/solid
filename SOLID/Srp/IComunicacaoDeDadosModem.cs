namespace SOLID.Srp
{
    public interface IComunicacaoDeDadosModem
    {
        public void EnviarComunicacao(string comunicacao);
        public char ReceberComunicacao();
    }
}
