namespace ProyectoDBP_TIENDA.Models
{
    public class Carrito
    {
        public string IdPro { get; set; } = null!;
        public string DesPro { get; set; } = null!;
        public double PrePro { get; set; }
        public int StkAct { get; set; }
        public int cantidad { get; set; }
    }
}
