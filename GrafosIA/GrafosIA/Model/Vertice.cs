using System;
using System.Collections.Generic;

namespace GrafosIA.Model
{
    public class Vertice
    {

        #region CTO

        public Vertice()
        {
            this.Valor = new Escenario();
            this.Estado = "Estado-0";
            this.VerticeId = Guid.NewGuid();
            Aristas = new List<Vertice>();
        }
        public Vertice(Escenario escenario, Vertice vertice, int num)
        {
            this.Valor = escenario;
            this.Estado = $"Estado-{num}";
            this.VerticeId = Guid.NewGuid();
            Aristas = new List<Vertice> { vertice };
        }

        #endregion

        public Guid VerticeId { get; set; }
        public string Estado { get; set; }
        public Escenario Valor { get; set; }
        public List<Vertice> Aristas { get; set; }

    }
}
