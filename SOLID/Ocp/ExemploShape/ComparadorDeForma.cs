using System;
using System.Collections;
using System.Collections.Generic;

namespace SOLID.Ocp.ExemploShape
{
    public class ComparadorDeForma : IComparer
    {
        private readonly IDictionary<Type, int> _dicionarioDeFormasComSuaPrioridade;

        public ComparadorDeForma()
        {
            _dicionarioDeFormasComSuaPrioridade = new Dictionary<Type, int>
            {
                {typeof(Circulo), 1},
                {typeof(Quadrado), 2}
            };
        }

        private int RetornarPrioridadeDeAcordoComOTipoDaForma(Type tipoDaForma) =>
            _dicionarioDeFormasComSuaPrioridade.TryGetValue(tipoDaForma, out var prioridade) 
                ? prioridade 
                : 0;

        public int Compare(object x, object y)
        {
            var prioridadePrimeiroObjeto = RetornarPrioridadeDeAcordoComOTipoDaForma(x?.GetType());
            var prioridadeSegundoObjeto = RetornarPrioridadeDeAcordoComOTipoDaForma(y?.GetType());
            return prioridadePrimeiroObjeto.CompareTo(prioridadeSegundoObjeto);
        }
    }
}
