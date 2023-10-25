using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbAula
{
    public string CodAula { get; set; } = null!;

    public string CursoAula { get; set; } = null!;

    public string LugarAula { get; set; } = null!;

    public int StkAula { get; set; }

    public string UniAula { get; set; } = null!;

    public DateTime FechAula { get; set; }

    public virtual TbDetalleAula? TbDetalleAulaCodAulaNavigation { get; set; }

    public virtual ICollection<TbDetalleAula> TbDetalleAulaLugarAulaNavigations { get; set; } = new List<TbDetalleAula>();
}
