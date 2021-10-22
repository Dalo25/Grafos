using GrafosIA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrafosIA.Extensions
{
    public static class GrafoExtension
    {
        public static (bool, bool) ValidMoveCabra(this Vertice oVertice)
        {
            var estado = oVertice.Valor;
            var valid = false;

            if (!estado.Granjero && !estado.Cabra && !estado.Lechuga && !estado.Lobo) { valid = true; }
            if (!estado.Granjero && !estado.Cabra && estado.Lechuga && estado.Lobo) { valid = true; }

            return (valid, estado.Cabra);
        }
        public static bool ValidMoveLobo(this Vertice oVertice)
        {
            var estado = oVertice.Valor;
            return !estado.Granjero && !estado.Lobo && estado.Cabra;
        }
        public static bool ValidMoveLechuga(this Vertice oVertice)
        {
            var estado = oVertice.Valor;
            return (!estado.Granjero && !estado.Cabra && !estado.Lechuga);
        }
        public static (bool, bool) ValidMoveGranjero(this Vertice oVertice)
        {
            var estado = oVertice.Valor;
            var valid = false;

            if (estado.Cabra && !estado.Lobo && !estado.Lechuga) { valid = true; }
            if (!estado.Cabra && estado.Lobo && estado.Lechuga) { valid = true; } 
            
            return (valid, estado.Granjero);
        }
    }
}
