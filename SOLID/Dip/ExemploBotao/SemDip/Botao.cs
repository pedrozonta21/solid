namespace SOLID.Dip.ExemploBotao.SemDip
{
    public class Botao
    {
        private readonly Lampada _lampada;

        public Botao(Lampada lampada) => _lampada = lampada;

        public void LigarObjeto() => _lampada.Ligar();

        public void DesligarObjeto() => _lampada.Desligar();
    }
}
