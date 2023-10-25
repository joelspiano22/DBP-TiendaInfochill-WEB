using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbOrdenCompra
{
    public string NumOco { get; set; } = null!;

    public DateTime FecOco { get; set; }

    public string CodProveedor { get; set; } = null!;

    public DateTime FecAte { get; set; }

    public string EstOco { get; set; } = null!;

    public virtual TbProveedor CodProveedorNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleCompra> TbDetalleCompras { get; set; } = new List<TbDetalleCompra>();
}
