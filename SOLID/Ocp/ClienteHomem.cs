namespace SOLID.Ocp
{
    public class ClienteHomem : SaudacaoAbstract
    {
        public override string RetornarSaudacao() => "E aí? Beleza?";

        public uint RetornarNumeroReservista() => 123456789;
    }
}
