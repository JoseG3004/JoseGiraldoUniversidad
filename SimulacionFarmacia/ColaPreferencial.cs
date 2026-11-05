using System;

namespace PuntoDeAtencion
{
    public class ColaPreferencial
    {
        private Persona[] elementos = new Persona[5];
        private int frente = 0;
        public int Cantidad { get; private set; } = 0;
        public int Capacidad => 5;

        public bool IsEmpty() => Cantidad == 0;
        public bool IsFull() => Cantidad == 5;

        public bool TryEncolar(Persona persona)
        {
            if (IsFull()) return false;

            // Buscar la posición de inserción según prioridad (de mayor a menor)
            int i = Cantidad - 1;
            while (i >= 0)
            {
                int posActual = (frente + i) % 5;
                if (elementos[posActual].Prioridad >= persona.Prioridad)
                {
                    break;
                }

                // Desplazar circularmente a la derecha los de menor prioridad
                int posSiguiente = (frente + i + 1) % 5;
                elementos[posSiguiente] = elementos[posActual];
                i--;
            }

            int posInsercion = (frente + i + 1) % 5;
            elementos[posInsercion] = persona;
            Cantidad++;
            return true;
        }

        public bool TryDesencolar(out Persona persona)
        {
            if (IsEmpty())
            {
                persona = null;
                return false;
            }

            persona = elementos[frente];
            elementos[frente] = null;

            frente = (frente + 1) % 5; // Avanza el frente circularmente
            Cantidad--;
            return true;
        }

        public bool TryPeek(out Persona persona)
        {
            if (IsEmpty())
            {
                persona = null;
                return false;
            }

            persona = elementos[frente];
            return true;
        }

        public void Mostrar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"=== COLA 3 - PREFERENCIAL ({Cantidad}/5) ===");
            Console.ResetColor();

            if (IsEmpty())
            {
                Console.WriteLine("  [Vacía]\n");
                return;
            }

            int idx = frente;
            for (int i = 0; i < Cantidad; i++)
            {
                Persona p = elementos[idx];
                Console.WriteLine($"  {i + 1}. {p.Nombre,-12} [{p.ObtenertipoPrioridad()}]");
                idx = (idx + 1) % 5;
            }
            Console.WriteLine();
        }
    }
}