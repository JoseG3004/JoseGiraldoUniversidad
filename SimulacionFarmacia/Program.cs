using System;

namespace PuntoDeAtencion
{
    internal class Program
    {
        static void Main()
        {
            // Colas
            Cola cola1 = new Cola();
            Cola cola2 = new Cola();
            ColaPreferencial colaPref = new ColaPreferencial();
            ColaDrenaje drenaje = new ColaDrenaje();

            // Cajas
            Caja cajaPreferencial = new Caja("Caja 3 (Preferencial)");
            Caja cajaNormal1 = new Caja("Caja 1 (Normal)");
            Caja cajaNormal2 = new Caja("Caja 2 (Normal)");

            // Utilidades
            RandomManager random = new RandomManager();
            Tiempo tiempo = new Tiempo();
            InterfazConsola interfaz = new InterfazConsola();

            bool generarPersona = true;
            int cdGenerarPersona = 0;
            int tiempoLlegada = 0;

            while (true)
            {
                // 1. Procesar tiempo de atención en cajas
                cajaPreferencial.ProcesarSegundo();
                cajaNormal1.ProcesarSegundo();
                cajaNormal2.ProcesarSegundo();

                // 2. Asignar personas de las colas a las cajas libres
                AsignarClientesACajas(colaPref, cola1, cola2, cajaPreferencial, cajaNormal1, cajaNormal2, random);

                // 3. Mover personas del Drenaje a las Colas de la tienda si hay espacio
                MoverDrenajeATienda(cola1, cola2, colaPref, drenaje);

                // 4. Generación periódica de nuevos clientes
                if (generarPersona)
                {
                    cdGenerarPersona = random.NextPersona();
                    tiempoLlegada = tiempo.MostrarTiempo();

                    Persona nueva = random.GenerarPersona();
                    IngresarPersona(nueva, cola1, cola2, colaPref, drenaje);

                    generarPersona = false;
                }
                else if (tiempo.MostrarTiempo() == cdGenerarPersona + tiempoLlegada)
                {
                    generarPersona = true;
                }

                // 5. Dibujar interfaz en pantalla
                interfaz.Renderizar(tiempo, cola1, cola2, colaPref, drenaje, cajaPreferencial, cajaNormal1, cajaNormal2);

                tiempo.SiguienteAccion();
            }
        }

        static void IngresarPersona(Persona p, Cola c1, Cola c2, ColaPreferencial cPref, ColaDrenaje drenaje)
        {
            // 1. Caso Cliente Preferencial
            if (p.EsPreferencial)
            {
                // Intento 1: Ir a la Cola Preferencial
                if (!cPref.TryEncolar(p))
                {
                    // Intento 2: Si la preferencial está llena, desborda hacia la cola normal menos llena
                    Cola colaDestino = (c1.Cantidad <= c2.Cantidad) ? c1 : c2;

                    if (colaDestino.TryEncolarOrdenado(p, out Persona expulsado))
                    {
                        // Si la cola normal estaba llena y tuvo que sacar a alguien de menor prioridad
                        if (expulsado != null)
                        {
                            drenaje.Encolar(expulsado);
                        }
                    }
                    else
                    {
                        // No cupo en la primera cola normal, intentamos en la otra
                        Cola otraCola = (colaDestino == c1) ? c2 : c1;
                        if (otraCola.TryEncolarOrdenado(p, out Persona expulsadoSegunda))
                        {
                            if (expulsadoSegunda != null)
                            {
                                drenaje.Encolar(expulsadoSegunda);
                            }
                        }
                        else
                        {
                            // Si ambas colas normales están saturadas con alta prioridad, va al drenaje
                            drenaje.Encolar(p);
                        }
                    }
                }
            }
            // 2. Caso Cliente Normal
            else
            {
                // El cliente normal busca la cola normal con menos gente
                Cola colaDestino = (c1.Cantidad <= c2.Cantidad) ? c1 : c2;

                if (colaDestino.TryEncolarOrdenado(p, out Persona expulsado))
                {
                    if (expulsado != null)
                    {
                        drenaje.Encolar(expulsado);
                    }
                }
                else
                {
                    // Intentar en la otra cola normal
                    Cola otraCola = (colaDestino == c1) ? c2 : c1;
                    if (otraCola.TryEncolarOrdenado(p, out expulsado))
                    {
                        if (expulsado != null)
                        {
                            drenaje.Encolar(expulsado);
                        }
                    }
                    else
                    {
                        drenaje.Encolar(p); // No hay lugar en la tienda
                    }
                }
            }
        }

        static void MoverDrenajeATienda(Cola c1, Cola c2, ColaPreferencial cPref, ColaDrenaje drenaje)
        {
            if (drenaje.IsEmpty()) return;

            if (drenaje.TryPeek(out Persona p))
            {
                bool acomodado = false;

                // 1. Intentar acomodar en Cola Preferencial si la persona es preferencial
                if (p.EsPreferencial && !cPref.IsFull())
                {
                    cPref.TryEncolar(p);
                    acomodado = true;
                }
                // 2. Intentar acomodar en Colas Normales (si no es preferencial o la cola preferencial está llena)
                else
                {
                    // Seleccionar la cola normal con menos personas
                    Cola destino = (c1.Cantidad <= c2.Cantidad) ? c1 : c2;

                    if (destino.TryEncolarOrdenado(p, out Persona desplazado))
                    {
                        acomodado = true;
                        // Si al insertar desplazó a alguien de menor prioridad, ese desplazado va al drenaje
                        if (desplazado != null)
                        {
                            drenaje.Encolar(desplazado);
                        }
                    }
                    else
                    {
                        // Intentar en la otra cola normal
                        Cola otra = (destino == c1) ? c2 : c1;
                        if (otra.TryEncolarOrdenado(p, out desplazado))
                        {
                            acomodado = true;
                            if (desplazado != null)
                            {
                                drenaje.Encolar(desplazado);
                            }
                        }
                    }
                }

                // Si la persona de la cabeza del drenaje logró entrar a una cola, la eliminamos del drenaje
                if (acomodado)
                {
                    drenaje.TryDesencolar(out _);
                }
            }
        }

        static void AsignarClientesACajas(ColaPreferencial cPref, Cola c1, Cola c2, Caja cajaPref, Caja caja1, Caja caja2, RandomManager random)
        {
            // ---------------------------------------------------------
            // 1. ATENCIÓN EN CAJA PREFERENCIAL (Caja 3)
            // ---------------------------------------------------------
            if (!cajaPref.Ocupada)
            {
                // Prioridad 1: Cola Preferencial
                if (cPref.TryDesencolar(out Persona p))
                {
                    cajaPref.Atender(p, random.TiempoAtencion());
                }
                // Prioridad 2: Si Preferencial está vacía, atiende de la Cola Normal más llena
                else
                {
                    Cola colaMasLlena = (c1.Cantidad >= c2.Cantidad) ? c1 : c2;
                    if (colaMasLlena.TryDesencolar(out p))
                    {
                        cajaPref.Atender(p, random.TiempoAtencion());
                    }
                }
            }

            // ---------------------------------------------------------
            // 2. ATENCIÓN EN CAJA NORMAL 1
            // ---------------------------------------------------------
            if (!caja1.Ocupada)
            {
                // Prioridad 1: Su propia cola (Cola 1)
                if (c1.TryDesencolar(out Persona p1))
                {
                    caja1.Atender(p1, random.TiempoAtencion());
                }
                // Prioridad 2: Si Cola 1 está vacía, ayuda a la Cola Preferencial
                else if (cPref.TryDesencolar(out p1))
                {
                    caja1.Atender(p1, random.TiempoAtencion());
                }
                // Prioridad 3: Si Preferencial también está vacía, ayuda a la Cola 2
                else if (c2.TryDesencolar(out p1))
                {
                    caja1.Atender(p1, random.TiempoAtencion());
                }
            }

            // ---------------------------------------------------------
            // 3. ATENCIÓN EN CAJA NORMAL 2
            // ---------------------------------------------------------
            if (!caja2.Ocupada)
            {
                // Prioridad 1: Su propia cola (Cola 2)
                if (c2.TryDesencolar(out Persona p2))
                {
                    caja2.Atender(p2, random.TiempoAtencion());
                }
                // Prioridad 2: Si Cola 2 está vacía, ayuda a la Cola Preferencial
                else if (cPref.TryDesencolar(out p2))
                {
                    caja2.Atender(p2, random.TiempoAtencion());
                }
                // Prioridad 3: Si Preferencial también está vacía, ayuda a la Cola 1
                else if (c1.TryDesencolar(out p2))
                {
                    caja2.Atender(p2, random.TiempoAtencion());
                }
            }
        }
    }
}