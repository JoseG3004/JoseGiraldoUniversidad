using System;

namespace PuntoDeAtencion
{
    public class ColaDrenaje
    {
        private Nodo cabeza;
        private Nodo cola;
        public int Cantidad { get; private set; }

        public ColaDrenaje()
        {
            cabeza = null;
            cola = null;
            Cantidad = 0;
        }

        // Insertar al final de la lista enlazada
        public void Encolar(Persona persona)
        {
            Nodo nuevoNodo = new Nodo(persona);

            if (IsEmpty())
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola.Siguiente = nuevoNodo;
                cola = nuevoNodo;
            }

            Cantidad++;
        }

        public bool TryDesencolar(out Persona persona)
        {
            if (IsEmpty())
            {
                persona = null;
                return false;
            }

            persona = cabeza.Persona;
            cabeza = cabeza.Siguiente;
            Cantidad--;

            if (cabeza == null)
            {
                cola = null;
            }

            return true;
        }

        public bool TryPeek(out Persona persona)
        {
            if (IsEmpty())
            {
                persona = null;
                return false;
            }

            persona = cabeza.Persona;
            return true;
        }

        public bool IsEmpty() => Cantidad == 0;

        public void Mostrar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"=== COLA DE DRENAJE / FUERA DE TIENDA (Total: {Cantidad}) ===");
            Console.ResetColor();

            if (IsEmpty())
            {
                Console.WriteLine("  [Sin personas afuera]\n");
                return;
            }

            Nodo actual = cabeza;
            int posicion = 1;

            while (actual != null)
            {
                Persona p = actual.Persona;
                string tipo = p.EsPreferencial ? $"[PREF - {p.ObtenertipoPrioridad()}]" : "[NORMAL]";
                Console.WriteLine($"  {posicion}. {p.Nombre,-12} {tipo}");

                actual = actual.Siguiente; // Avanzamos al siguiente nodo
                posicion++;
            }
            Console.WriteLine();
        }
    }
}