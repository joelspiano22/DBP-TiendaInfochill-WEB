namespace ProyectoDBP_TIENDA.Models
{
    public class TemporalVenta
    {
        public int IdPro { get; set; }
        public string DesPro { get; set; }
        public double PrePro { get; set; }
        public int StkAct { get; set; }
        public int cantidad { get; set; }
        public virtual ICollection<TbFactura> TbFacturas { get; set; } = new List<TbFactura>();
        public virtual ICollection<TbDetalleFactura> TbDetalleFacturas { get; set; } = new List<TbDetalleFactura>();
    }
}
