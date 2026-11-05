using Modelos;
using System.Collections.Generic;

namespace BaseDatos
{
    public class Datos
    {
        public static List<Granja> BaseGranjas = new List<Granja>()
        {
            new Granja
            {
                ID = 1,
                Nombre = "granja san josé",
                Cultivo = "papa capira",
                Ubicacion = "sonsón",
                Ciclos = 12,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "tubérculo", "leguminosa" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Carlos Gómez", Telefono = "+57 300 123 4501" },
                TamanoPlantacion = 12.5
            },
            new Granja
            {
                ID = 2,
                Nombre = "agropecuaria la unión",
                Cultivo = "papa criolla",
                Ubicacion = "la unión",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "tubérculo" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "María Rodríguez", Telefono = "+57 311 987 6502" },
                TamanoPlantacion = 8.0
            },
            new Granja
            {
                ID = 3,
                Nombre = "hacienda el oasis",
                Cultivo = "zanahoria",
                Ubicacion = "el santuario",
                Ciclos = 4,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Jorge Zuluaga", Telefono = "+57 312 456 7803" },
                TamanoPlantacion = 5.4
            },
            new Granja
            {
                ID = 4,
                Nombre = "finca la montaña",
                Cultivo = "remolacha",
                Ubicacion = "marinilla",
                Ciclos = 3,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Ana María Hoyos", Telefono = "+57 314 222 3304" },
                TamanoPlantacion = 4.2
            },
            new Granja
            {
                ID = 5,
                Nombre = "flores & cultivos la ceja",
                Cultivo = "uchuva",
                Ubicacion = "la ceja",
                Ciclos = 12,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Luis Fernando Rendón", Telefono = "+57 301 555 6605" },
                TamanoPlantacion = 18.0
            },
            new Granja
            {
                ID = 6,
                Nombre = "granja rionegro bio",
                Cultivo = "tomate chonto",
                Ubicacion = "rionegro",
                Ciclos = 5,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Paula Andrea Botero", Telefono = "+57 310 777 8806" },
                TamanoPlantacion = 6.5
            },
            new Granja
            {
                ID = 7,
                Nombre = "agro peñol",
                Cultivo = "tomate de árbol",
                Ubicacion = "el peñol",
                Ciclos = 8,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa", "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Gonzalo Giraldo", Telefono = "+57 313 888 9907" },
                TamanoPlantacion = 9.1
            },
            new Granja
            {
                ID = 8,
                Nombre = "finca el milagro",
                Cultivo = "brócoli",
                Ubicacion = "guarne",
                Ciclos = 4,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Claudia Patricia Morales", Telefono = "+57 315 111 2208" },
                TamanoPlantacion = 3.8
            },
            new Granja
            {
                ID = 9,
                Nombre = "cultivos el carmen",
                Cultivo = "fríjol cargamanto",
                Ubicacion = "el carmen de viboral",
                Ciclos = 3,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Esteban Vargas", Telefono = "+57 316 333 4409" },
                TamanoPlantacion = 7.3
            },
            new Granja
            {
                ID = 10,
                Nombre = "granja san vicente",
                Cultivo = "cebolla de rama",
                Ubicacion = "san vicente ferrer",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces", "tubérculo" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Diana Marcela Ospina", Telefono = "+57 317 444 5510" },
                TamanoPlantacion = 5.0
            },
            new Granja
            {
                ID = 11,
                Nombre = "cafetal abejorral",
                Cultivo = "café especial",
                Ubicacion = "abejorral",
                Ciclos = 12,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Hernán Ramírez", Telefono = "+57 318 666 7711" },
                TamanoPlantacion = 25.0
            },
            new Granja
            {
                ID = 12,
                Nombre = "finca la piedra",
                Cultivo = "habichuela",
                Ubicacion = "guatapé",
                Ciclos = 4,
                Procesos = new List<string> { "floración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Sofía Tobón", Telefono = "+57 319 888 1112" },
                TamanoPlantacion = 4.0
            },
            new Granja
            {
                ID = 13,
                Nombre = "cacao & frutas san rafael",
                Cultivo = "cacao",
                Ubicacion = "san rafael",
                Ciclos = 18,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo industrial", "cultivo permanente" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Mateo Alzate", Telefono = "+57 320 123 9913" },
                TamanoPlantacion = 30.5
            },
            new Granja
            {
                ID = 14,
                Nombre = "platanera san carlos",
                Cultivo = "plátano",
                Ubicacion = "san carlos",
                Ciclos = 12,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente", "raíces" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Andrés Felipe Marín", Telefono = "+57 321 456 8814" },
                TamanoPlantacion = 14.2
            },
            new Granja
            {
                ID = 15,
                Nombre = "granja granada verde",
                Cultivo = "maíz",
                Ubicacion = "granada",
                Ciclos = 7,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa", "cereal" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Beatriz Elena Henao", Telefono = "+57 322 789 7715" },
                TamanoPlantacion = 11.0
            },
            new Granja
            {
                ID = 16,
                Nombre = "trapiche cocorná",
                Cultivo = "caña panelera",
                Ubicacion = "cocorná",
                Ciclos = 14,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo industrial" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Jaime Alberto Castaño", Telefono = "+57 323 111 6616" },
                TamanoPlantacion = 22.8
            },
            new Granja
            {
                ID = 17,
                Nombre = "agrícola argelia",
                Cultivo = "café",
                Ubicacion = "argelia",
                Ciclos = 12,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Lucía Jaramillo", Telefono = "+57 300 222 5517" },
                TamanoPlantacion = 16.4
            },
            new Granja
            {
                ID = 18,
                Nombre = "frutales nariño",
                Cultivo = "cítricos",
                Ubicacion = "nariño",
                Ciclos = 10,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Oscar Bedoya", Telefono = "+57 301 333 4418" },
                TamanoPlantacion = 19.5
            },
            new Granja
            {
                ID = 19,
                Nombre = "finca concepción",
                Cultivo = "guayaba",
                Ubicacion = "concepción",
                Ciclos = 5,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cereal" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Verónica Ríos", Telefono = "+57 302 444 3319" },
                TamanoPlantacion = 6.2
            },
            new Granja
            {
                ID = 20,
                Nombre = "granja alejandría",
                Cultivo = "papaya",
                Ubicacion = "alejandría",
                Ciclos = 9,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Gabriel Esteban Villa", Telefono = "+57 303 555 2220" },
                TamanoPlantacion = 8.7
            },
            new Granja
            {
                ID = 21,
                Nombre = "exportadora hass sonsón",
                Cultivo = "aguacate hass",
                Ubicacion = "sonsón",
                Ciclos = 24,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Santiago Carmona", Telefono = "+57 304 666 1121" },
                TamanoPlantacion = 45.0
            },
            new Granja
            {
                ID = 22,
                Nombre = "papa criolla la unión",
                Cultivo = "papa criolla",
                Ubicacion = "la unión",
                Ciclos = 4,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "tubérculo" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Martha Isabel Cano", Telefono = "+57 305 777 0022" },
                TamanoPlantacion = 7.5
            },
            new Granja
            {
                ID = 23,
                Nombre = "agro santuario",
                Cultivo = "cebolla huevo",
                Ubicacion = "el santuario",
                Ciclos = 4,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Diego Fernando Soto", Telefono = "+57 310 111 9923" },
                TamanoPlantacion = 6.0
            },
            new Granja
            {
                ID = 24,
                Nombre = "hortalizas marinilla",
                Cultivo = "lechuga batavia",
                Ubicacion = "marinilla",
                Ciclos = 3,
                Procesos = new List<string> { "floración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Camila Aristizábal", Telefono = "+57 311 222 8824" },
                TamanoPlantacion = 3.5
            },
            new Granja
            {
                ID = 25,
                Nombre = "berry farms la ceja",
                Cultivo = "arándanos",
                Ubicacion = "la ceja",
                Ciclos = 8,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Alejandro Echeverri", Telefono = "+57 312 333 7725" },
                TamanoPlantacion = 13.0
            },
            new Granja
            {
                ID = 26,
                Nombre = "invernaderos rionegro",
                Cultivo = "pimentón",
                Ubicacion = "rionegro",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Natalia Cardona", Telefono = "+57 313 444 6626" },
                TamanoPlantacion = 4.8
            },
            new Granja
            {
                ID = 27,
                Nombre = "frutales el peñol",
                Cultivo = "granadilla",
                Ubicacion = "el peñol",
                Ciclos = 10,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Ramón Elías Vallejo", Telefono = "+57 314 555 5527" },
                TamanoPlantacion = 10.2
            },
            new Granja
            {
                ID = 28,
                Nombre = "granja guarne frío",
                Cultivo = "coliflor",
                Ubicacion = "guarne",
                Ciclos = 5,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "tubérculo", "raíces" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Adriana María Duque", Telefono = "+57 315 666 4428" },
                TamanoPlantacion = 5.6
            },
            new Granja
            {
                ID = 29,
                Nombre = "el carmen orgánico",
                Cultivo = "acelga",
                Ubicacion = "el carmen de viboral",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa", "cereal" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Felipe Montoya", Telefono = "+57 316 777 3329" },
                TamanoPlantacion = 4.1
            },
            new Granja
            {
                ID = 30,
                Nombre = "agro san vicente",
                Cultivo = "arracacha",
                Ubicacion = "san vicente ferrer",
                Ciclos = 4,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Gloria Inés Franco", Telefono = "+57 317 888 2230" },
                TamanoPlantacion = 6.8
            },
            new Granja
            {
                ID = 31,
                Nombre = "finca la esperanza abejorral",
                Cultivo = "fríjol",
                Ubicacion = "abejorral",
                Ciclos = 7,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Joaquín Emilio Pérez", Telefono = "+57 318 999 1131" },
                TamanoPlantacion = 9.0
            },
            new Granja
            {
                ID = 32,
                Nombre = "cacaotera san luis",
                Cultivo = "cacao fino de aroma",
                Ubicacion = "san luis",
                Ciclos = 12,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo industrial" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Yolanda Agudelo", Telefono = "+57 319 000 0032" },
                TamanoPlantacion = 28.4
            },
            new Granja
            {
                ID = 33,
                Nombre = "cítricos puerto triunfo",
                Cultivo = "naranja valencia",
                Ubicacion = "puerto triunfo",
                Ciclos = 10,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Mario Alberto Urrego", Telefono = "+57 320 111 2233" },
                TamanoPlantacion = 21.0
            },
            new Granja
            {
                ID = 34,
                Nombre = "aguacates el retiro",
                Cultivo = "aguacate hass",
                Ubicacion = "el retiro",
                Ciclos = 18,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Marcela Villegas", Telefono = "+57 321 222 3334" },
                TamanoPlantacion = 32.6
            },
            new Granja
            {
                ID = 35,
                Nombre = "granja altamira",
                Cultivo = "gulupa",
                Ubicacion = "sonsón",
                Ciclos = 9,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Rodrigo Salazar", Telefono = "+57 322 333 4435" },
                TamanoPlantacion = 17.8
            },
            new Granja
            {
                ID = 36,
                Nombre = "fresas la unión",
                Cultivo = "fresa",
                Ubicacion = "la unión",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Isabel Cristina Osorio", Telefono = "+57 323 444 5536" },
                TamanoPlantacion = 6.5
            },
            new Granja
            {
                ID = 37,
                Nombre = "verduras el santuario",
                Cultivo = "repollo rojo",
                Ubicacion = "el santuario",
                Ciclos = 3,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Faber de Jesús Suárez", Telefono = "+57 300 555 6637" },
                TamanoPlantacion = 4.3
            },
            new Granja
            {
                ID = 38,
                Nombre = "agro marinilla norte",
                Cultivo = "espinaca",
                Ubicacion = "marinilla",
                Ciclos = 4,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Manuela Giraldo", Telefono = "+57 301 666 7738" },
                TamanoPlantacion = 3.9
            },
            new Granja
            {
                ID = 39,
                Nombre = "hortensias la ceja",
                Cultivo = "hortensias",
                Ubicacion = "la ceja",
                Ciclos = 12,
                Procesos = new List<string> { "floración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo industrial" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Mauricio Londoño", Telefono = "+57 302 777 8839" },
                TamanoPlantacion = 20.0
            },
            new Granja
            {
                ID = 40,
                Nombre = "cultivos el llano",
                Cultivo = "tomate cherry",
                Ubicacion = "rionegro",
                Ciclos = 5,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Daniela Morales", Telefono = "+57 303 888 9940" },
                TamanoPlantacion = 5.5
            },
            new Granja
            {
                ID = 41,
                Nombre = "finca el embalse",
                Cultivo = "fríjol",
                Ubicacion = "el peñol",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Héctor Iván García", Telefono = "+57 304 999 0041" },
                TamanoPlantacion = 7.0
            },
            new Granja
            {
                ID = 42,
                Nombre = "hortalizas guarne",
                Cultivo = "cilantro",
                Ubicacion = "guarne",
                Ciclos = 4,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Sandra Milena Ortiz", Telefono = "+57 305 111 2242" },
                TamanoPlantacion = 2.8
            },
            new Granja
            {
                ID = 43,
                Nombre = "agro el carmen",
                Cultivo = "ajo",
                Ubicacion = "el carmen de viboral",
                Ciclos = 5,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Sebastián Marulanda", Telefono = "+57 310 222 3343" },
                TamanoPlantacion = 4.7
            },
            new Granja
            {
                ID = 44,
                Nombre = "finca san vicente alto",
                Cultivo = "zanahoria",
                Ubicacion = "san vicente ferrer",
                Ciclos = 7,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces", "leguminosa" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Ligia Helena Jiménez", Telefono = "+57 311 333 4444" },
                TamanoPlantacion = 8.3
            },
            new Granja
            {
                ID = 45,
                Nombre = "cultivos granada sur",
                Cultivo = "papa capira",
                Ubicacion = "granada",
                Ciclos = 6,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "tubérculo", "cultivo industrial" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Alvaro José Beltrán", Telefono = "+57 312 444 5545" },
                TamanoPlantacion = 9.8
            },
            new Granja
            {
                ID = 46,
                Nombre = "cañaduzal cocorná",
                Cultivo = "caña",
                Ubicacion = "cocorná",
                Ciclos = 12,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo industrial" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Néstor Raúl Hoyos", Telefono = "+57 313 555 6646" },
                TamanoPlantacion = 18.2
            },
            new Granja
            {
                ID = 47,
                Nombre = "finca san carlos verde",
                Cultivo = "yuca",
                Ubicacion = "san carlos",
                Ciclos = 10,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente", "raíces" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Teresa de Jesús Mejía", Telefono = "+57 314 666 7747" },
                TamanoPlantacion = 11.5
            },
            new Granja
            {
                ID = 48,
                Nombre = "mandarinas san rafael",
                Cultivo = "mandarina oneco",
                Ubicacion = "san rafael",
                Ciclos = 9,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Guillermo León Muñoz", Telefono = "+57 315 777 8848" },
                TamanoPlantacion = 14.0
            },
            new Granja
            {
                ID = 49,
                Nombre = "agropecuaria el retiro",
                Cultivo = "mora",
                Ubicacion = "el retiro",
                Ciclos = 12,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Liliana María Tamayo", Telefono = "+57 316 888 9949" },
                TamanoPlantacion = 12.0
            },
            new Granja
            {
                ID = 50,
                Nombre = "cereales sonsón",
                Cultivo = "fríjol cargamanto",
                Ubicacion = "sonsón",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cereal", "leguminosa" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "César Augusto Arango", Telefono = "+57 317 999 0050" },
                TamanoPlantacion = 15.0
            },
            new Granja
            {
                ID = 51,
                Nombre = "agropecuaria la esperanza",
                Cultivo = "papa criolla",
                Ubicacion = "sonsón",
                Ciclos = 4,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "tubérculo" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Gabriel Jaime Marín", Telefono = "+57 318 000 1151" },
                TamanoPlantacion = 8.5
            },
            new Granja
            {
                ID = 52,
                Nombre = "finca los pinos",
                Cultivo = "fríjol cargamanto",
                Ubicacion = "la unión",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Vanessa Alexandra Gil", Telefono = "+57 319 111 2252" },
                TamanoPlantacion = 10.0
            },
            new Granja
            {
                ID = 53,
                Nombre = "cultivos la perla",
                Cultivo = "zanahoria",
                Ubicacion = "el santuario",
                Ciclos = 5,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Omar de Jesús Gómez", Telefono = "+57 320 222 3353" },
                TamanoPlantacion = 6.4
            },
            new Granja
            {
                ID = 54,
                Nombre = "granja el carmen norte",
                Cultivo = "lechuga batavia",
                Ubicacion = "marinilla",
                Ciclos = 3,
                Procesos = new List<string> { "floración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Karen Yuliet Ramírez", Telefono = "+57 321 333 4454" },
                TamanoPlantacion = 3.2
            },
            new Granja
            {
                ID = 55,
                Nombre = "agro flores san antonio",
                Cultivo = "crisantemos",
                Ubicacion = "la ceja",
                Ciclos = 12,
                Procesos = new List<string> { "floración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo industrial" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Juan Camilo Serna", Telefono = "+57 322 444 5555" },
                TamanoPlantacion = 24.0
            },
            new Granja
            {
                ID = 56,
                Nombre = "hacienda el tablazo",
                Cultivo = "tomate de árbol",
                Ubicacion = "rionegro",
                Ciclos = 10,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Patricia Elena Naranjo", Telefono = "+57 323 555 6656" },
                TamanoPlantacion = 12.8
            },
            new Granja
            {
                ID = 57,
                Nombre = "cultivos guatapé verde",
                Cultivo = "habichuela",
                Ubicacion = "guatapé",
                Ciclos = 4,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Rubén Darío Henao", Telefono = "+57 300 666 7757" },
                TamanoPlantacion = 5.1
            },
            new Granja
            {
                ID = 58,
                Nombre = "finca la cabaña",
                Cultivo = "brocoli",
                Ubicacion = "guarne",
                Ciclos = 4,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Eliana María Agudelo", Telefono = "+57 301 777 8858" },
                TamanoPlantacion = 4.5
            },
            new Granja
            {
                ID = 59,
                Nombre = "agro carmen sur",
                Cultivo = "cebolla de rama",
                Ubicacion = "el carmen de viboral",
                Ciclos = 5,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Jorge Mario Quintero", Telefono = "+57 302 888 9959" },
                TamanoPlantacion = 6.2
            },
            new Granja
            {
                ID = 60,
                Nombre = "granja san vicente verde",
                Cultivo = "arracacha",
                Ubicacion = "san vicente ferrer",
                Ciclos = 8,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Luz Marina Parra", Telefono = "+57 303 999 0060" },
                TamanoPlantacion = 7.7
            },
            new Granja
            {
                ID = 61,
                Nombre = "cafetal la selva",
                Cultivo = "café",
                Ubicacion = "abejorral",
                Ciclos = 12,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Francisco Luis Toro", Telefono = "+57 304 000 1161" },
                TamanoPlantacion = 22.0
            },
            new Granja
            {
                ID = 62,
                Nombre = "finca el penón",
                Cultivo = "granadilla",
                Ubicacion = "el peñol",
                Ciclos = 9,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Ángela María Carmona", Telefono = "+57 305 111 2262" },
                TamanoPlantacion = 8.9
            },
            new Granja
            {
                ID = 63,
                Nombre = "cacao san rafael organico",
                Cultivo = "cacao",
                Ubicacion = "san rafael",
                Ciclos = 18,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo industrial" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Edwin Alberto Montoya", Telefono = "+57 310 222 3363" },
                TamanoPlantacion = 35.0
            },
            new Granja
            {
                ID = 64,
                Nombre = "platanera el río",
                Cultivo = "plátano",
                Ubicacion = "san carlos",
                Ciclos = 11,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Dora Alicia Rendón", Telefono = "+57 311 333 4464" },
                TamanoPlantacion = 13.6
            },
            new Granja
            {
                ID = 65,
                Nombre = "granja granada central",
                Cultivo = "maíz",
                Ubicacion = "granada",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cereal" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Alonso de Jesús Bedoya", Telefono = "+57 312 444 5565" },
                TamanoPlantacion = 9.4
            },
            new Granja
            {
                ID = 66,
                Nombre = "molienda cocorná norte",
                Cultivo = "caña",
                Ubicacion = "cocorná",
                Ciclos = 13,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo industrial" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Yessica Tatiana Silva", Telefono = "+57 313 555 6666" },
                TamanoPlantacion = 16.0
            },
            new Granja
            {
                ID = 67,
                Nombre = "agro argelia alta",
                Cultivo = "café especial",
                Ubicacion = "argelia",
                Ciclos = 12,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Bernardo Antonio Zuluaga", Telefono = "+57 314 666 7767" },
                TamanoPlantacion = 18.5
            },
            new Granja
            {
                ID = 68,
                Nombre = "frutales nariño sur",
                Cultivo = "aguacate hass",
                Ubicacion = "nariño",
                Ciclos = 18,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Lina María Castañeda", Telefono = "+57 315 777 8868" },
                TamanoPlantacion = 27.3
            },
            new Granja
            {
                ID = 69,
                Nombre = "finca concepción alta",
                Cultivo = "guayaba",
                Ubicacion = "concepción",
                Ciclos = 7,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Victor Hugo Alarcón", Telefono = "+57 316 888 9969" },
                TamanoPlantacion = 7.8
            },
            new Granja
            {
                ID = 70,
                Nombre = "agro alejandría este",
                Cultivo = "papaya",
                Ubicacion = "alejandría",
                Ciclos = 8,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Mónica Patricia Ocampo", Telefono = "+57 317 999 0070" },
                TamanoPlantacion = 9.0
            },
            new Granja
            {
                ID = 71,
                Nombre = "exportadora sonsón premium",
                Cultivo = "higo",
                Ubicacion = "sonsón",
                Ciclos = 12,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Hernando José Flórez", Telefono = "+57 318 000 1171" },
                TamanoPlantacion = 14.5
            },
            new Granja
            {
                ID = 72,
                Nombre = "agro la unión frío",
                Cultivo = "papa capira",
                Ubicacion = "la unión",
                Ciclos = 5,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "tubérculo" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Claudia Elena Sepúlveda", Telefono = "+57 319 111 2272" },
                TamanoPlantacion = 8.2
            },
            new Granja
            {
                ID = 73,
                Nombre = "hortalizas el santuario",
                Cultivo = "remolacha",
                Ubicacion = "el santuario",
                Ciclos = 4,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Raúl Fernando Guzmán", Telefono = "+57 320 222 3373" },
                TamanoPlantacion = 4.9
            },
            new Granja
            {
                ID = 74,
                Nombre = "cultivos marinilla centro",
                Cultivo = "espinaca",
                Ubicacion = "marinilla",
                Ciclos = 3,
                Procesos = new List<string> { "floración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Sara Isabel Blandón", Telefono = "+57 321 333 4474" },
                TamanoPlantacion = 3.6
            },
            new Granja
            {
                ID = 75,
                Nombre = "exportadora uchuva la ceja",
                Cultivo = "uchuva",
                Ubicacion = "la ceja",
                Ciclos = 10,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Felipe Andrés Restrepo", Telefono = "+57 322 444 5575" },
                TamanoPlantacion = 16.5
            },
            new Granja
            {
                ID = 76,
                Nombre = "cultivos rionegro valle",
                Cultivo = "pimentón",
                Ubicacion = "rionegro",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Juliana María López", Telefono = "+57 323 555 6676" },
                TamanoPlantacion = 6.0
            },
            new Granja
            {
                ID = 77,
                Nombre = "finca el peñol alto",
                Cultivo = "tomate chonto",
                Ubicacion = "el peñol",
                Ciclos = 5,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Sergio Alejandro Ruiz", Telefono = "+57 300 666 7777" },
                TamanoPlantacion = 5.8
            },
            new Granja
            {
                ID = 78,
                Nombre = "agropecuaria guarne norte",
                Cultivo = "cilantro",
                Ubicacion = "guarne",
                Ciclos = 3,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Catalina Gómez", Telefono = "+57 301 777 8878" },
                TamanoPlantacion = 2.5
            },
            new Granja
            {
                ID = 79,
                Nombre = "finca el carmen verde",
                Cultivo = "acelga",
                Ubicacion = "el carmen de viboral",
                Ciclos = 4,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                Clima = "templado",
                TipoCultivo = new List<string> { "raíces" },
                Contacto = new Contacto { Nombre = "Iván Darío Cardona", Telefono = "+57 302 888 9979" },
                TamanoPlantacion = 4.0
            },
            new Granja
            {
                ID = 80,
                Nombre = "hortalizas san vicente",
                Cultivo = "cebolla huevo",
                Ubicacion = "san vicente ferrer",
                Ciclos = 5,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Martha Lucia Herrera", Telefono = "+57 303 999 0080" },
                TamanoPlantacion = 5.2
            },
            new Granja
            {
                ID = 81,
                Nombre = "finca la montaña abejorral",
                Cultivo = "tomate de árbol",
                Ubicacion = "abejorral",
                Ciclos = 9,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Camilo Eduardo Soto", Telefono = "+57 304 000 1181" },
                TamanoPlantacion = 8.0
            },
            new Granja
            {
                ID = 82,
                Nombre = "agro san luis caliente",
                Cultivo = "yuca",
                Ubicacion = "san luis",
                Ciclos = 10,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Rosa Amelia Galeano", Telefono = "+57 305 111 2282" },
                TamanoPlantacion = 12.4
            },
            new Granja
            {
                ID = 83,
                Nombre = "frutales puerto triunfo",
                Cultivo = "limón tahití",
                Ubicacion = "puerto triunfo",
                Ciclos = 12,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "David Gustavo Morales", Telefono = "+57 310 222 3383" },
                TamanoPlantacion = 26.0
            },
            new Granja
            {
                ID = 84,
                Nombre = "cultivos el retiro frío",
                Cultivo = "mora",
                Ubicacion = "el retiro",
                Ciclos = 8,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Lorena María Marín", Telefono = "+57 311 333 4484" },
                TamanoPlantacion = 9.5
            },
            new Granja
            {
                ID = 85,
                Nombre = "finca sonsón frutal",
                Cultivo = "gulupa",
                Ubicacion = "sonsón",
                Ciclos = 10,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Jaime Enrique Pineda", Telefono = "+57 312 444 5585" },
                TamanoPlantacion = 19.0
            },
            new Granja
            {
                ID = 86,
                Nombre = "fresas la unión alta",
                Cultivo = "fresa",
                Ubicacion = "la unión",
                Ciclos = 7,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Jessica Andrea Viana", Telefono = "+57 313 555 6686" },
                TamanoPlantacion = 7.1
            },
            new Granja
            {
                ID = 87,
                Nombre = "agro santuario campo",
                Cultivo = "repollo verde",
                Ubicacion = "el santuario",
                Ciclos = 4,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Germán Alonso Dávila", Telefono = "+57 314 666 7787" },
                TamanoPlantacion = 5.0
            },
            new Granja
            {
                ID = 88,
                Nombre = "finca marinilla este",
                Cultivo = "perejil",
                Ubicacion = "marinilla",
                Ciclos = 3,
                Procesos = new List<string> { "floración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Mayerly Tatiana Rueda", Telefono = "+57 315 777 8888" },
                TamanoPlantacion = 3.0
            },
            new Granja
            {
                ID = 89,
                Nombre = "cultivos hortensias el retiro",
                Cultivo = "hortensias",
                Ubicacion = "el retiro",
                Ciclos = 12,
                Procesos = new List<string> { "floración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo industrial" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Esteban Mauricio Botero", Telefono = "+57 316 888 9989" },
                TamanoPlantacion = 23.5
            },
            new Granja
            {
                ID = 90,
                Nombre = "invernadero rionegro norte",
                Cultivo = "tomate cherry",
                Ubicacion = "rionegro",
                Ciclos = 5,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Astrid Elena Montes", Telefono = "+57 317 999 0090" },
                TamanoPlantacion = 6.7
            },
            new Granja
            {
                ID = 91,
                Nombre = "agrícola el peñol verde",
                Cultivo = "habichuela",
                Ubicacion = "el peñol",
                Ciclos = 4,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Cristian David Serna", Telefono = "+57 318 000 1191" },
                TamanoPlantacion = 4.4
            },
            new Granja
            {
                ID = 92,
                Nombre = "cultivos guarne verde",
                Cultivo = "coliflor",
                Ubicacion = "guarne",
                Ciclos = 4,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Nora Cecilia Gaviria", Telefono = "+57 319 111 2292" },
                TamanoPlantacion = 4.8
            },
            new Granja
            {
                ID = 93,
                Nombre = "finca el carmen agro",
                Cultivo = "ajo",
                Ubicacion = "el carmen de viboral",
                Ciclos = 6,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "raíces" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Juan José Morales", Telefono = "+57 320 222 3393" },
                TamanoPlantacion = 5.9
            },
            new Granja
            {
                ID = 94,
                Nombre = "granja san vicente campo",
                Cultivo = "fríjol cargamanto",
                Ubicacion = "san vicente ferrer",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "leguminosa" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Luz Elida Hincapié", Telefono = "+57 321 333 4494" },
                TamanoPlantacion = 8.1
            },
            new Granja
            {
                ID = 95,
                Nombre = "agro granada central",
                Cultivo = "papa criolla",
                Ubicacion = "granada",
                Ciclos = 5,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "tubérculo" },
                Clima = "templado",
                Contacto = new Contacto { Nombre = "Gonzalo de Jesús Cardona", Telefono = "+57 322 444 5595" },
                TamanoPlantacion = 7.3
            },
            new Granja
            {
                ID = 96,
                Nombre = "trapiche cocorná sur",
                Cultivo = "caña",
                Ubicacion = "cocorná",
                Ciclos = 12,
                Procesos = new List<string> { "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo industrial" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Flor María Alzate", Telefono = "+57 323 555 6696" },
                TamanoPlantacion = 15.2
            },
            new Granja
            {
                ID = 97,
                Nombre = "platanera san carlos este",
                Cultivo = "plátano",
                Ubicacion = "san carlos",
                Ciclos = 11,
                Procesos = new List<string> { "fructificación", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Victor Manuel Soto", Telefono = "+57 300 666 7797" },
                TamanoPlantacion = 12.0
            },
            new Granja
            {
                ID = 98,
                Nombre = "cítricos san rafael norte",
                Cultivo = "mandarina oneco",
                Ubicacion = "san rafael",
                Ciclos = 10,
                Procesos = new List<string> { "floración", "fructificación" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "caliente",
                Contacto = new Contacto { Nombre = "Gloria Patricia Rendón", Telefono = "+57 301 777 8898" },
                TamanoPlantacion = 11.8
            },
            new Granja
            {
                ID = 99,
                Nombre = "exportadora hass el retiro",
                Cultivo = "aguacate hass",
                Ubicacion = "el retiro",
                Ciclos = 20,
                Procesos = new List<string> { "floración", "fructificación", "maduración" },
                CanalVenta = "internacional",
                TipoCultivo = new List<string> { "cultivo permanente" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Mauricio Alejandro Tobón", Telefono = "+57 302 888 9999" },
                TamanoPlantacion = 38.0
            },
            new Granja
            {
                ID = 100,
                Nombre = "granja sonsón sur",
                Cultivo = "maíz",
                Ubicacion = "sonsón",
                Ciclos = 6,
                Procesos = new List<string> { "floración", "maduración" },
                CanalVenta = "nacional",
                TipoCultivo = new List<string> { "cereal" },
                Clima = "frío",
                Contacto = new Contacto { Nombre = "Olga Lucía Villegas", Telefono = "+57 303 999 0000" },
                TamanoPlantacion = 10.5
            }
        };
    }
}