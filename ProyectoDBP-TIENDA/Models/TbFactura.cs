using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbFactura
{
    public int IdFac { get; set; }

    public int CodUsu { get; set; }

    public DateTime FechaReg { get; set; }

    public virtual TbUsuario CodUsuNavigation { get; set; } = null!;
}
