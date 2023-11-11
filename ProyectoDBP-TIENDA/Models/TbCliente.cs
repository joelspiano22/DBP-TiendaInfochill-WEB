using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbCliente
{
    public int CodCliente { get; set; }

    public string NomCli { get; set; } = null!;

    public string ApeCli { get; set; } = null!;

    public string DniCli { get; set; } = null!;

    public string TlfCli { get; set; } = null!;

    public string CorreoCli { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string IdUsu { get; set; } = null!;

    public virtual TbUsuario IdUsuNavigation { get; set; } = null!;
}
