using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbProveedor
{
    public string CodProveedor { get; set; } = null!;

    public string RazSocial { get; set; } = null!;

    public string DirProveedor { get; set; } = null!;

    public string? TlfProveedor { get; set; }

    public string RepVenta { get; set; } = null!;

    public virtual ICollection<TbOrdenCompra> TbOrdenCompras { get; set; } = new List<TbOrdenCompra>();
}
