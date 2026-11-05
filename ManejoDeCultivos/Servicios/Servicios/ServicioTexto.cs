using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Servicios
{
    public class ServicioTexto
    {
        public static string NormalizarTexto(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            string textoLimpio = texto.Trim().ToLower();

            var tildes = new Dictionary<char, char>
            {
                { 'á', 'a' },
                { 'é', 'e' },
                { 'í', 'i' },
                { 'ó', 'o' },
                { 'ú', 'u' },
                { 'ü', 'u' }
            };

            List<char> resultado = new List<char>();

            foreach (char c in textoLimpio)
            {
                if (tildes.ContainsKey(c))
                {
                    resultado.Add(tildes[c]);
                }
                else
                {
                    resultado.Add(c);
                }
            }

            return new string(resultado.ToArray());
        }
    }
}

