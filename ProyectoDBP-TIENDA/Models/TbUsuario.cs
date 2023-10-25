using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbUsuario
{
    public string CodCliente { get; set; } = null!;

    public string? ContraUsu { get; set; }

    public virtual TbCliente CodClienteNavigation { get; set; } = null!;
}
