using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbDetalleFactura
{
    public int IdFac { get; set; }

    public int CodUsu { get; set; }

    public int IdPro { get; set; }

    public int CanVen { get; set; }

    public decimal PreVen { get; set; }

    public virtual TbUsuario CodUsuNavigation { get; set; } = null!;

    public virtual TbProducto IdProNavigation { get; set; } = null!;
}
