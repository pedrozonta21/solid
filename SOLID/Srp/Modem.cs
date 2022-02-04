namespace SOLID.Srp
{
    public class Modem : IConexaoModem, IComunicacaoDeDadosModem
    {
        public void DiscarConexao(string pno) { }

        public void DesligarConexao() { }

        public void EnviarComunicacao(string comunicacao) { }

        public char ReceberComunicacao() => new();
    }
}
