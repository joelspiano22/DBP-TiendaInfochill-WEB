using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbProducto
{
    public int IdPro { get; set; }

    public string DesPro { get; set; } = null!;

    public decimal PrePro { get; set; }

    public int StkAct { get; set; }

    public int StkMin { get; set; }

    public string? CatePro { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual ICollection<TbDetalleCompra> TbDetalleCompras { get; set; } = new List<TbDetalleCompra>();

    public virtual TbDetalleFactura? TbDetalleFactura { get; set; }
}
