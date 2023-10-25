using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbDetalleAula
{
    public string CodAula { get; set; } = null!;

    public string LugarAula { get; set; } = null!;

    public DateTime FechAula { get; set; }

    public virtual TbAula CodAulaNavigation { get; set; } = null!;

    public virtual TbAula LugarAulaNavigation { get; set; } = null!;
}
