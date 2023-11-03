using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDobleV.Utility
{
    public class Utilidades
    {
        public static List<string> GetNotFoundListError() => new() { Constantes.NotFound };
    }

    public class Constantes
    {
        public const string NotFound = "No se encontraron registros.";
    }
}
