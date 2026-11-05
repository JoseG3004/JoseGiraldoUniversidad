using System;

namespace PuntoDeAtencion
{
    public class Cola
    {
        private Persona[] elementos = new Persona[5];
        private int frente = 0;
        public int Cantidad { get; private set; } = 0;
        public int Capacidad => 5;

        public bool IsEmpty() => Cantidad == 0;
        public bool IsFull() => Cantidad == 5;

        /// <summary>
        /// Inserta de forma ordenada por Prioridad (3 > 2 > 1 > 0).
        /// Si la cola está llena, desplaza a la persona con menor prioridad al drenaje.
        /// </summary>
        public bool TryEncolarOrdenado(Persona nuevaPersona, out Persona desplazadoAlDrenaje)
        {
            desplazadoAlDrenaje = null;

            // CASO 1: La cola está llena
            if (IsFull())
            {
                int posUltimo = (frente + Cantidad - 1) % 5;
                Persona personaMasRezagada = elementos[posUltimo];

                // Si la nueva persona tiene menor o igual prioridad que el último de la cola,
                // la nueva persona no cabe y debe irse directo al drenaje.
                if (nuevaPersona.Prioridad <= personaMasRezagada.Prioridad)
                {
                    desplazadoAlDrenaje = nuevaPersona;
                    return false;
                }

                // Si la nueva persona tiene MAYOR prioridad que el último,
                // expulsamos al último al drenaje y acomodamos a la nueva persona.
                desplazadoAlDrenaje = personaMasRezagada;
                elementos[posUltimo] = null;
                Cantidad--;
            }

            // CASO 2: Inserción ordenada en el arreglo circular
            int i = Cantidad - 1;
            while (i >= 0)
            {
                int posActual = (frente + i) % 5;
                if (elementos[posActual].Prioridad >= nuevaPersona.Prioridad)
                {
                    break;
                }

                // Desplazar a la derecha los de menor prioridad
                int posSiguiente = (frente + i + 1) % 5;
                elementos[posSiguiente] = elementos[posActual];
                i--;
            }

            int posInsercion = (frente + i + 1) % 5;
            elementos[posInsercion] = nuevaPersona;
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

            frente = (frente + 1) % 5;
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

        public void Mostrar(string nombreCola, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"=== {nombreCola} ({Cantidad}/5) ===");
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
                string detalle = p.EsPreferencial ? $"[{p.ObtenertipoPrioridad()}]" : "[Normal]";
                Console.WriteLine($"  {i + 1}. {p.Nombre,-12} (Prio: {p.Prioridad}) {detalle}");

                idx = (idx + 1) % 5;
            }
            Console.WriteLine();
        }
    }
}