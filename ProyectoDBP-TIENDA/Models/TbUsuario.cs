using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbUsuario
{
    public int CodCliente { get; set; }

    public string? ContraUsu { get; set; }

    public virtual TbCliente CodClienteNavigation { get; set; } = null!;
}
