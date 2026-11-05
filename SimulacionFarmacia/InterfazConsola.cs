using System;

namespace PuntoDeAtencion
{
    public class InterfazConsola
    {
        public void Renderizar(Tiempo tiempo, Cola c1, Cola c2, ColaPreferencial cPref, ColaDrenaje drenaje, Caja cajaPref, Caja caja1, Caja caja2)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================================");
            Console.WriteLine($"   SIMULADOR DE FARMACIA  |  Tiempo: {tiempo.MostrarTiempo()}s");
            Console.WriteLine("==================================================================");
            Console.ResetColor();

            // Estado de las Cajas
            Console.WriteLine("\n--- ESTADO DE CAJAS ---");
            MostrarCaja(cajaPref, ConsoleColor.Yellow);
            MostrarCaja(caja1, ConsoleColor.Green);
            MostrarCaja(caja2, ConsoleColor.Blue);

            // Estado de las Colas Internas
            Console.WriteLine("\n--- COLAS EN TIENDA (Max 5) ---");
            cPref.Mostrar();
            c1.Mostrar("COLA 1 - NORMAL", ConsoleColor.Green);
            c2.Mostrar("COLA 2 - NORMAL", ConsoleColor.Blue);

            // Estado del Drenaje
            drenaje.Mostrar();
        }

        private void MostrarCaja(Caja caja, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"[{caja.Nombre,-18}] ");
            Console.ResetColor();

            if (caja.Ocupada)
            {
                Console.WriteLine($"Atendiendo a: {caja.ClienteActual.Nombre,-10} | Quedan: {caja.TiempoRestante}s");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("DISPONIBLE");
                Console.ResetColor();
            }
        }
    }
}