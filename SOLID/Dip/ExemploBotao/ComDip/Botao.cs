namespace SOLID.Dip.ExemploBotao.ComDip
{
    public class Botao
    {
        private readonly IObjetoEletrico _objetoEletrico;

        public Botao(IObjetoEletrico objetoEletrico) => _objetoEletrico = objetoEletrico;

        public void LigarObjeto() => _objetoEletrico.Ligar();

        public void DesligarObjeto() => _objetoEletrico.Desligar();
    }
}
