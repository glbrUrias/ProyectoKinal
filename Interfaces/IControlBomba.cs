namespace GasolineraKalum.Interfaces
{
    public interface IControlBomba
    {
        public void Despachar(int cantidad);
        int VerNivelCapacidad();
    }
}