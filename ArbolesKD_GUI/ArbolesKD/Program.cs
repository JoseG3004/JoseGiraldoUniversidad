using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolesKD
{
    public class Program
    {
        static void BuscarUbicaciones(SisUbicacion arbol)
        {
            Console.WriteLine("\n=== BUSCAR UBICACIONES POR RADIO ===");

            double x, y, radio;

            Console.Write("Ingresa tu coordenada X: ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Valor inválido. Ingresa X nuevamente: ");
            }

            Console.Write("Ingresa tu coordenada Y: ");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.Write("Valor inválido. Ingresa Y nuevamente: ");
            }

            Console.Write("Ingresa el radio de búsqueda: ");
            while (!double.TryParse(Console.ReadLine(), out radio) || radio < 0)
            {
                Console.Write("Ingresa un radio válido (mayor o igual a 0): ");
            }

            double[] centro = { x, y };

            List<Nodo> resultados = arbol.BuscarEnRadio(centro, radio);

            if (resultados.Count == 0)
            {
                Console.WriteLine("\nNo se encontraron ubicaciones dentro del radio.");
                return;
            }

            Console.WriteLine($"\nSe encontraron {resultados.Count} ubicaciones:");

            foreach (Nodo nodo in resultados)
            {
                double distancia = arbol.Magnitud(centro, nodo.Punto);

                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Nombre: {nodo.Nombre}");
                Console.WriteLine($"Categoría: {nodo.Categoria}");
                Console.WriteLine($"Coordenadas: ({nodo.Punto[0]}, {nodo.Punto[1]})");
                Console.WriteLine($"Distancia: {distancia:F2}");
            }

            Console.WriteLine("--------------------------------");
        }

        static void BuscarCercania(SisUbicacion arbol)
        {
            Console.Write("Ingresa tu coordenada X: ");
            double x = double.Parse(Console.ReadLine()!);

            Console.Write("Ingresa tu coordenada Y: ");
            double y = double.Parse(Console.ReadLine()!);

            double[] centro = { x, y };

            List<Nodo> cercanas = arbol.BuscarMasCercanas(centro);

            Console.WriteLine("\nLas ubicaciones más cercanas son:");

            foreach (Nodo nodo in cercanas)
            {
                double distancia = arbol.Magnitud(centro, nodo.Punto);

                Console.WriteLine(
                    $"{nodo.Nombre} | {nodo.Categoria} | " +
                    $"Distancia: {distancia:F2}");
            }
        }

        static void BuscarCategoria(SisUbicacion arbol)
        {
            Console.Write("Ingresa tu coordenada X: ");
            double x = double.Parse(Console.ReadLine()!);

            Console.Write("Ingresa tu coordenada Y: ");
            double y = double.Parse(Console.ReadLine()!);

            double[] centro = { x, y };

            Console.Write("Ingresa la Categoria\n(Farmacia, Restaurante, Salud, Comercio, Parque)\n:");
            string cat = Console.ReadLine();

            List<Nodo> encontrados =arbol.BuscarMasCercanasPorCategoria(centro, cat);

            foreach (Nodo lugar in encontrados)
            {
                Console.WriteLine(
                    $"{lugar.Nombre} - {lugar.Categoria} - " +
                    $"Distancia: {arbol.Magnitud(lugar.Punto, centro):F2}");
            }
        }
        [STAThread]
        static void Main(string[] args)
        {
            SisUbicacion arbol = new SisUbicacion();

            // Cargar las ubicaciones que definiste en tu árbol.
            arbol.Inicializador();

            // Interfaz gráfica (el menú de consola anterior queda en MenuConsola).
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal(arbol));
        }

        // Menú de consola original (ya no se usa al arrancar; se conserva por si lo necesitas).
        static void MenuConsola(SisUbicacion arbol)
        {

            Console.WriteLine("=== SISTEMA DE UBICACIONES ===");
            Console.WriteLine("1. Buscar ubicaciones por Radio");
            Console.WriteLine("2. Buscar ubicaciones por Cercania");
            Console.WriteLine("3. Buscar ubicaciones por Categoria");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opción: ");

            string? opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    BuscarUbicaciones(arbol);
                    break;

                case "2":
                    BuscarCercania(arbol);
                    break;

                case "3":
                    BuscarCategoria(arbol);
                    break;

                case "0":
                    Console.WriteLine("Hasta pronto.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
 }
