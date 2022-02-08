using System;

namespace SOLID.Dip.ExemploBotao.SemDip
{
    public class Botao
    {
        private readonly Lampada _lampada;
        private readonly Computador _computador;

        public Botao(Lampada lampada, Computador computador)
        {
            _lampada = lampada;
            _computador = computador;
        }

        public void LigarObjeto(Type tipoObjeto)
        {
            if(typeof(Lampada) == tipoObjeto)
                _lampada.Ligar();
            else if(typeof(Computador) == tipoObjeto)
                _computador.Ligar();
        }

        public void DesligarObjeto(Type tipoObjeto)
        {
            if (typeof(Lampada) == tipoObjeto)
                _lampada.Desligar();
            else if (typeof(Computador) == tipoObjeto)
                _computador.Desligar();
        }
    }
}
