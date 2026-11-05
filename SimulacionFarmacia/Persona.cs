using System;
using System.Collections.Generic;
using System.Text;

namespace PuntoDeAtencion
{
    public class Persona
    {
        public string Nombre { get; private set; }
        public int Prioridad { get; private set; }
        public bool EsPreferencial => Prioridad > 0; // Expresión directa: 1, 2 y 3 son preferenciales

        private static readonly string[] Nombres = {
            "Juan", "María", "Carlos", "Ana", "Luis",
            "Sofía", "Andrés", "Valentina", "David", "Camila",
            "Miguel", "Daniela", "José", "Laura", "Diego",
            "Paula", "Sebastián", "Natalia", "Daniel", "Gabriela"
        };

        public Persona(int index, int probabilidad)
        {
            Nombre = Nombres[index % Nombres.Length];
            Prioridad = CalcularPrioridad(probabilidad, index);
        }

        private int CalcularPrioridad(int prob, int index)
        {
            if (prob < 70) return 0; // 70% Normal
            if (prob < 85) return 1; // 15% Discapacitado
            if (prob < 95) return 2; // 10% Anciano

            // 5% Embarazada (si el índice es impar, se asigna como Anciano)
            return (index % 2 != 0) ? 2 : 3;
        }

        public string ObtenertipoPrioridad()
        {
            switch (Prioridad)
            {
                case 1: return "Discapacitado";
                case 2: return "Anciano";
                case 3: return "Mujer Embarazada";
                default: return "Normal";
            }
        }
    }
}
