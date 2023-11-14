using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbProveedor
{
    public int CodProveedor { get; set; }

    public string RazSocial { get; set; } = null!;

    public string DirProveedor { get; set; } = null!;

    public string? TlfProveedor { get; set; }

    public string RepVenta { get; set; } = null!;
}
