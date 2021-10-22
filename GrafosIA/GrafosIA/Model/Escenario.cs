namespace GrafosIA.Model
{
    public class Escenario
    {
        public Escenario() { }
        public Escenario(bool granjero, bool lobo, bool cabra, bool lechuga)
        {
            Granjero = granjero;
            Lobo = lobo;
            Cabra = cabra;
            Lechuga = lechuga;
        }

        public bool Granjero { get; set; }
        public bool Lobo { get; set; }
        public bool Cabra { get; set; }
        public bool Lechuga { get; set; }
    }
}
