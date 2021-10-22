using GrafosIA.Helper;
using GrafosIA.Model;
using System;

namespace GrafosIA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generar Grafo - El granjero, la cabra, el lobo y la col.");
            Console.WriteLine("PARA TENER EN CUENTA: \n 1) True = Derecha \n 2) False = Izquierda. \n\n");
            //Console.Read();

            Console.WriteLine("#########  TODOS estan en el lado Izquierdo ##############\n");
            
            GrafoHelper.Grafo = new Vertice(); // Crear inicio del Grafo


            do
            {
                GrafoHelper.Count++;  //Acumulador numero de estados que se generan
                GrafoHelper.GenerarGrafo(GrafoHelper.Grafo);

                if (GrafoHandler.IsError) { break; } // Si detectas un error, Salte del flujo y cierra el grafo.

            } while (!GrafoHelper.ObtenerMeta(GrafoHelper.Grafo));

            if (GrafoHandler.IsError)
            {
                Console.WriteLine("\n\n######### HA OCURRIDO UN ERROR EN LA CONSTRUCCION DEL GRAFO O INCUMPLIMIENTO DE LAS RESTRICCIONES ##############\n\n");
            }
            else
            {
                Console.WriteLine("\n\n#########  GRAFO UI ##############\n\n");
                GrafoHelper.GetAll(GrafoHelper.Grafo);
            }


            Console.Read();
        }
    }
}
