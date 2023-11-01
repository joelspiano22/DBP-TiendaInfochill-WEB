using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbDetalleFactura
{
    public int IdPro { get; set; }

    public int CanVen { get; set; }

    public decimal PreVen { get; set; }

    public virtual TbProducto IdProNavigation { get; set; } = null!;
}
