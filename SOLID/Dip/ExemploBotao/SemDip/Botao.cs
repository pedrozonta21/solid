using System;

namespace SOLID.Dip.ExemploBotao.SemDip
{
    public class Botao
    {
        private readonly Lampada _lampada;
        private readonly Computador _computador;
        //variável pra Furadeira _furadeira

        public Botao(Lampada lampada, Computador computador)
        {
            _lampada = lampada;
            _computador = computador;
            //atribui o novo parâmetro Furadeira furadeira do construtor para _furadeira
        }

        public void LigarObjeto(Type tipoObjeto)
        {
            if(typeof(Lampada) == tipoObjeto)
                _lampada.Ligar();
            if(typeof(Computador) == tipoObjeto)
                _computador.Ligar();
            //if para _furadeira.Ligar();
        }

        public void DesligarObjeto(Type tipoObjeto)
        {
            if (typeof(Lampada) == tipoObjeto)
                _lampada.Desligar();
            if (typeof(Computador) == tipoObjeto)
                _computador.Desligar();
            //if para _furadeira.Desligar();
        }
    }
}
