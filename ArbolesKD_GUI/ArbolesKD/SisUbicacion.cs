using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesKD
{
    public class SisUbicacion
    {
        public Nodo raiz { get; private set; }
        public void Insertar((double X, double Y) punto, string nombre, string categoria)
        {
            double[] coords = new double[] { punto.X, punto.Y };

            Nodo nuevoNodo = new Nodo(coords, nombre, categoria);

            if (raiz == null)
            {
                nuevoNodo.Eje = 0;
                nuevoNodo.Padre = null;
                this.raiz = nuevoNodo;
                return;
            }

            Nodo actual = raiz;
            Nodo PadreEncontrado = null;

            while (actual != null)
            {
                PadreEncontrado = actual;

                if (coords[actual.Eje] < actual.Punto[actual.Eje])
                {
                    actual = actual.Izquierdo;
                }
                else
                {
                    actual = actual.Derecho;
                }
            }

            nuevoNodo.Padre = PadreEncontrado;
            nuevoNodo.Eje = 1 - PadreEncontrado.Eje;

            if (coords[PadreEncontrado.Eje] < PadreEncontrado.Punto[PadreEncontrado.Eje])
            {
                PadreEncontrado.Izquierdo = nuevoNodo;
            }
            else
            {
                PadreEncontrado.Derecho = nuevoNodo;
            }
        }

        public void Inicializador()
        {
            // --- FARMACIAS ---
            Insertar((10, 3), "Farmacia San Jose", "Farmacia");
            Insertar((25, 12), "Farmacia Cruz Verde", "Farmacia");
            Insertar((45, 8), "Farmacia Pasteur", "Farmacia");
            Insertar((60, 30), "Farmacia San Pablo", "Farmacia");
            Insertar((82, 15), "Farmacia La Rebaja", "Farmacia");
            Insertar((18, 55), "Farmacia Multidrogas", "Farmacia");
            Insertar((35, 78), "Farmacia Económica", "Farmacia");
            Insertar((70, 65), "Farmacia Biocura", "Farmacia");
            Insertar((88, 92), "Farmacia FarmaVida", "Farmacia");
            Insertar((5, 85), "Farmacia Central", "Farmacia");

            // --- RESTAURANTES ---
            Insertar((15, 20), "Restaurante El Sabor", "Restaurante");
            Insertar((30, 5), "Pizzería Bella Italia", "Restaurante");
            Insertar((52, 18), "Hamburguesas El Corral", "Restaurante");
            Insertar((75, 22), "Sushi Roll Express", "Restaurante");
            Insertar((90, 10), "Asadero Don Pedro", "Restaurante");
            Insertar((12, 60), "Café Gourmet", "Restaurante");
            Insertar((40, 45), "Taquería El Mariachi", "Restaurante");
            Insertar((68, 50), "Restaurante Pacífico", "Restaurante");
            Insertar((85, 70), "Panadería La Espiga", "Restaurante");
            Insertar((22, 90), "Crepes & Waffles", "Restaurante");

            // --- CENTROS DE SALUD / HOSPITALES ---
            Insertar((8, 35), "Hospital Central", "Salud");
            Insertar((28, 42), "Clínica San Rafael", "Salud");
            Insertar((50, 60), "Centro Médico Norte", "Salud");
            Insertar((65, 85), "Hospital Infantil", "Salud");
            Insertar((95, 40), "Clínica de la Mujer", "Salud");
            Insertar((42, 25), "Centro de Odontología", "Salud");
            Insertar((78, 5), "Laboratorio Clínico Express", "Salud");
            Insertar((5, 70), "Puesto de Salud Sur", "Salud");
            Insertar((80, 95), "Clínica Oftalmológica", "Salud");
            Insertar((33, 98), "Hospital Universitario", "Salud");

            // --- SUPERMERCADOS Y COMERCIO ---
            Insertar((5, 5), "Supermercado Éxito", "Comercio");
            Insertar((20, 28), "Tienda Ara", "Comercio");
            Insertar((38, 12), "Supermercado Jumbo", "Comercio");
            Insertar((58, 5), "Tiendas D1", "Comercio");
            Insertar((80, 38), "Centro Comercial Gran Plaza", "Comercio");
            Insertar((15, 80), "Ferretería El Martillo", "Comercio");
            Insertar((48, 88), "Librería Nacional", "Comercio");
            Insertar((62, 72), "Tienda de Ropa Style", "Comercio");
            Insertar((92, 82), "Supermercado Carulla", "Comercio");
            Insertar((2, 45), "Centro Comercial Unicentro", "Comercio");

            // --- PARQUES Y RECREACIÓN ---
            Insertar((18, 10), "Parque Principal", "Parque");
            Insertar((40, 32), "Parque Botánico", "Parque");
            Insertar((62, 18), "Cancha de Fútbol El Gol", "Parque");
            Insertar((85, 28), "Parque Infantil Las Cumbres", "Parque");
            Insertar((98, 5), "Gimnasio Smart Fit", "Parque");
            Insertar((8, 92), "Parque Ecológico El Lago", "Parque");
            Insertar((28, 68), "Polideportivo Municipal", "Parque");
            Insertar((55, 52), "Parque Simón Bolívar", "Parque");
            Insertar((72, 90), "Club Campestre", "Parque");
            Insertar((90, 60), "Gimnasio Bodytech", "Parque");
        }

        public List<Nodo> BuscarEnRadio(double[] centro, double radio)
        {
            List<Nodo> resultados = new List<Nodo>();

            BuscarRecursivo(raiz, centro, radio, resultados);

            return resultados;
        }

        public double Magnitud(double[] A, double[] B)
        {
            double dx = B[0] - A[0];
            double dy = B[1] - A[1];
            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        }

        private void BuscarRecursivo(Nodo? actual,double[] centro,double radio,List<Nodo> resultados)
        {
            // Caso base: no hay nodo que explorar
            if (actual == null)
            {
                return;
            }

            // Calcular la diferencia según el eje del nodo
            double diferencia;

            if (actual.Eje == 0)
            {
                diferencia = centro[0] - actual.Punto[0];
            }
            else
            {
                diferencia = centro[1] - actual.Punto[1];
            }

            // Calcular la distancia al cuadrado
            double dx = actual.Punto[0] - centro[0];
            double dy = actual.Punto[1] - centro[1];

            double distanciaCuadrada = Math.Pow(dx,2) + Math.Pow(dy, 2);
            double radioCuadrado = Math.Pow(radio, 2);

            // Si el nodo está dentro del círculo, agregarlo
            if (distanciaCuadrada <= radioCuadrado)
            {
                resultados.Add(actual);
            }

            // Explorar el hijo izquierdo si el círculo puede alcanzarlo
            if (diferencia <= radio)
            {
                BuscarRecursivo(actual.Izquierdo,centro,radio,resultados);
            }

            // Explorar el hijo derecho si el círculo puede alcanzarlo
            if (diferencia >= -radio)
            {
                BuscarRecursivo(actual.Derecho,centro,radio,resultados);
            }
        }

        public List<Nodo> BuscarMasCercanas(double[] centro)
        {
            int cantidadAConservar = 5;

            List<(Nodo nodo, double distancia)> resultados = new List<(Nodo nodo, double distancia)>();

            BuscarCercanasRecursivo(raiz,centro,resultados,cantidadAConservar);

            return resultados.OrderBy(r => r.distancia).Select(r => r.nodo).ToList();
        }

        private void BuscarCercanasRecursivo(Nodo? actual,double[] centro,List<(Nodo nodo, double distancia)> resultados,int cantidadAConservar){
            if (actual == null)
            {
                return;
            }

            // Calcular la distancia al nodo actual.
            double distancia = Magnitud(actual.Punto, centro);

            // Agregar el candidato y ordenar por distancia.
            resultados.Add((actual, distancia));

            resultados.Sort((a, b) => a.distancia.CompareTo(b.distancia));

            // Conservar solamente los mejores candidatos.
            if (resultados.Count > cantidadAConservar)
            {
                resultados.RemoveAt(resultados.Count - 1);
            }

            // Determinar el eje de división.
            double diferencia;

            if (actual.Eje == 0)
            {
                diferencia = centro[0] - actual.Punto[0];
            }
            else
            {
                diferencia = centro[1] - actual.Punto[1];
            }

            // Explorar primero el lado donde está el centro.
            Nodo? cercano;
            Nodo? lejano;

            if (diferencia < 0)
            {
                cercano = actual.Izquierdo;
                lejano = actual.Derecho;
            }
            else
            {
                cercano = actual.Derecho;
                lejano = actual.Izquierdo;
            }

            BuscarCercanasRecursivo(cercano,centro,resultados,cantidadAConservar);

            // Distancia al plano de división.
            double distanciaAlPlano = Math.Abs(diferencia);

            // Si aún faltan candidatos, explorar la otra rama.
            // Si ya hay cinco, explorarla solo si podría mejorar
            // la distancia del candidato más lejano.
            if (resultados.Count < cantidadAConservar || distanciaAlPlano < resultados[resultados.Count - 1].distancia){
                BuscarCercanasRecursivo(lejano,centro,resultados,cantidadAConservar);
            }
        }

        public List<Nodo> BuscarMasCercanasPorCategoria(double[] centro, string categoria)
        {
            const int cantidadAConservar = 5;

            List<(Nodo nodo, double distancia)> resultados = new List<(Nodo nodo, double distancia)>();

            BuscarCategoriaRecursivo(raiz, centro, categoria, resultados, cantidadAConservar);

            return resultados.OrderBy(r => r.distancia).Select(r => r.nodo).ToList();
        }


        private void BuscarCategoriaRecursivo(Nodo? actual,double[] centro,string categoria,List<(Nodo nodo, double distancia)> resultados,int cantidadAConservar)
        {
            if (actual == null)
                return;

            // 1. Solo agregar lugares de la categoría solicitada
            if (string.Equals(actual.Categoria,categoria,StringComparison.OrdinalIgnoreCase))
            {
                double distancia = Magnitud(actual.Punto, centro);

                resultados.Add((actual, distancia));

                resultados.Sort(
                    (a, b) => a.distancia.CompareTo(b.distancia));

                if (resultados.Count > cantidadAConservar)resultados.RemoveAt(resultados.Count - 1);
            }

            // 2. Calcular la diferencia en el eje de división
            double diferencia;

            if (actual.Eje == 0)
                diferencia = centro[0] - actual.Punto[0];
            else
                diferencia = centro[1] - actual.Punto[1];

            // 3. Elegir qué rama explorar primero
            Nodo? cercano;
            Nodo? lejano;

            if (diferencia < 0)
            {
                cercano = actual.Izquierdo;
                lejano = actual.Derecho;
            }
            else
            {
                cercano = actual.Derecho;
                lejano = actual.Izquierdo;
            }

            BuscarCategoriaRecursivo(cercano, centro, categoria,resultados, cantidadAConservar);

            // 4. Decidir si vale la pena explorar la otra rama
            double distanciaAlPlano = Math.Abs(diferencia);

            if (resultados.Count < cantidadAConservar || distanciaAlPlano <= resultados[resultados.Count - 1].distancia)
            {
                BuscarCategoriaRecursivo(lejano, centro, categoria,resultados, cantidadAConservar);
            }
        }

    }
}
