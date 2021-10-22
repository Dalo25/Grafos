using GrafosIA.Extensions;
using GrafosIA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrafosIA.Helper
{
    public static class GrafoHandler
    {
        public static Vertice Grafo { get; set; }
        public static int Count { get; set; }
        public static bool IsError { get; set; }

        public static void GenerarGrafo(Vertice oVertice)
        {
            var estado = oVertice.Valor;
            if (!estado.Granjero)
            {
                MoverCabra(oVertice);
            }
            else
            {
                MoverGranjeroSolo(oVertice);
                if (!ValidarEstado(Grafo)) { IsError = false; return; }
            }            
        }

        public static void MoverCabra(Vertice oVertice) 
        {
            var isValid = oVertice.ValidMoveCabra();
            if (isValid.Item1)
            {
                var estado = oVertice.Valor;
                MoverEscenario(true, estado.Lobo, true, estado.Lechuga, oVertice);
                Console.WriteLine($"{Count}) Mover Cabra al lado {GetLado(isValid.Item2)}.");
            }
        }
        public static void MoverLobo(Vertice oVertice) 
        {
            var estado = oVertice.Valor;
            MoverEscenario(true, true, estado.Cabra, estado.Lechuga, oVertice);
            Console.WriteLine($"{Count}) Mover lobo al lado derecho.");
        }
        public static void MoverLechuga(Vertice oVertice)
        {
            if (oVertice.ValidMoveLechuga())
            {
                var estado = oVertice.Valor;
                MoverEscenario(true, estado.Lobo, true, estado.Lechuga, oVertice);
                Console.WriteLine($"{Count}) Mover Lechuga y Granjero al lado Derecho.");
            }
        }
        public static void MoverGranjeroSolo(Vertice oVertice)
        {
            var isValid = oVertice.ValidMoveGranjero();
            if (isValid.Item1)
            {
                var estado = oVertice.Valor;
                MoverEscenario(true, estado.Lobo, true, estado.Lechuga, oVertice);
                Console.WriteLine($"{Count}) Granjero Cruza solo al lado {GetLado(isValid.Item2)}.");
            }
        }


        #region PRIVATE

        private static bool ValidarEstado(Vertice oVertice)
        {
            var estado = oVertice.Valor;
            if (estado.Lobo == estado.Cabra && estado.Lobo != estado.Granjero) { return false; }
            if (estado.Cabra == estado.Lechuga && estado.Lechuga != estado.Granjero) { return false; }
            return true;
        }
        private static Vertice AgregarVertice(bool granjero, bool lobo, bool cabra, bool lechuga, Vertice oVertice)
        {
            var escenario = new Escenario(granjero, lobo, cabra, lechuga);
            return new Vertice(escenario, oVertice, Count);
        }
        private static void MoverEscenario(bool granjero, bool lobo, bool cabra, bool lechuga, Vertice oVertice)
        {
            Grafo = AgregarVertice(granjero, lobo, cabra, lechuga, oVertice);
        }             
        private static string GetLado(bool lado) =>  lado? "Derecho" : "Izquierdo";

        #endregion

    }
}
