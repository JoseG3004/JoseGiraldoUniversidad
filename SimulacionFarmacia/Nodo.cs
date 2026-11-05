namespace PuntoDeAtencion
{
    public class Nodo
    {
        public Persona Persona { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Persona persona)
        {
            Persona = persona;
            Siguiente = null;
        }
    }
}