using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbDetalleCompra
{
    public string NumOco { get; set; } = null!;

    public string IdPro { get; set; } = null!;

    public int CanPed { get; set; }

    public virtual TbProducto IdProNavigation { get; set; } = null!;

    public virtual TbOrdenCompra NumOcoNavigation { get; set; } = null!;
}
