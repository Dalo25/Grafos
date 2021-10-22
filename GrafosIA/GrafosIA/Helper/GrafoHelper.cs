using GrafosIA.Model;
using System;

namespace GrafosIA.Helper
{
    public static class GrafoHelper
    {
        public static Vertice Grafo { get; set; }
        public static int Count { get; set; }
        public static bool IsError { get; set; }

        public static void GetAll(Vertice vertice, string sangria = "")
        {
            if (Grafo != null)
            {
                Console.WriteLine($"{sangria}{vertice.Estado}");
                vertice.Aristas.ForEach(item =>
                {
                    GetAll(item, "\t");
                });
            }
        }

        //OBJETIVO FINAL (TODO EN EL MISMO LADO - DERECHO)
        public static bool ObtenerMeta(Vertice oVertice)
        {
            var item = oVertice.Valor;
            var isValid = item.Granjero && item.Cabra && item.Lechuga && item.Lobo;
            return isValid;
        }
        public static void GenerarGrafo(Vertice oVertice)
        {
            var estado = oVertice.Valor;
            if (!ValidarEstado(oVertice)) { IsError = true; return; }  // (RESTRICCIONES) Verifica que todos los estados del grafo(G, C, L, LG)

            //MOVER CABRA  - Cruzar SOLO
            if (estado.Granjero == false && estado.Cabra == false && estado.Lechuga == false && estado.Lobo == false)
            {
                Console.WriteLine($"{Count}) Mover Cabra al lado derecho.");
                MoverEscenario(true, estado.Lobo, true, estado.Lechuga, oVertice, true);
                Console.WriteLine($"{Count}) Granjero Cruza solo al lado izquierdo.");
                return;
            }
            
            //MOVER LOBO
            if (estado.Granjero == false && estado.Lobo == false && estado.Cabra == true)
            {
                MoverEscenario(true, true, estado.Cabra, estado.Lechuga, oVertice);
                Console.WriteLine($"{Count}) Mover lobo al lado derecho.");
                return;
            }

            //MOVER CABRA (IZQUIERDO) 
            if (estado.Granjero == true && estado.Lobo == true && estado.Cabra == true)
            {
                MoverEscenario(false, estado.Lobo, false, estado.Lechuga, oVertice);
                Console.WriteLine($"{Count}) Mover Cabra y Granjero al lado izquierdo.");
                return;
            }

            //MOVER LECHUGA - - Cruzar SOLO
            if (estado.Granjero == false && estado.Cabra == false && estado.Lechuga == false)
            {
                Console.WriteLine($"{Count}) Mover Lechuga y Granjero al lado Derecho.");
                MoverEscenario(true, estado.Lobo, estado.Cabra, true, oVertice, true);
                Console.WriteLine($"{Count}) Granjero Cruza solo al lado IZQUIERDO.");
                return;
            }

            //VOLVER A MOVER A LA CABRA
            if (estado.Granjero == false && estado.Cabra == false && estado.Lechuga == true && estado.Lobo == true)
            {
                MoverEscenario(true, estado.Lobo, true, estado.Lechuga, oVertice);
                Console.WriteLine($"{Count}) Mover Granjero y la cabra al lado Derecho.");
                return;
            }
        }

        #region PRIVATE

        /// <summary>
        /// VALIDACION DE ESTADOS - True DERECHA y FALSE IZQUIERDA
        /// </summary>
        /// <param name="oVertice"></param>
        /// <returns></returns>
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
        private static void MoverEscenario(bool granjero, bool lobo, bool cabra, bool lechuga, Vertice oVertice, bool moveGranjero = false)
        {
            Grafo = AgregarVertice(granjero, lobo, cabra, lechuga, oVertice);
            if (moveGranjero)
            {
                Count++;
                Grafo = AgregarVertice(false, lobo, cabra, lechuga, Grafo);
            }
        }

        #endregion
    }
}
