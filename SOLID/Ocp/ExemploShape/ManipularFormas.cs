using System.Collections;

namespace SOLID.Ocp.ExemploShape
{
    public class ManipularFormas
    {
        public void DesenharFormas(ArrayList formas)
        {
            formas.Sort(new ComparadorDeForma());
            foreach (IForma forma in formas) forma.DesenharForma();
        }
    }
}
