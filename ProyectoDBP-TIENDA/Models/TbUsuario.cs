using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbUsuario
{
    public int CodUsu { get; set; }

    public string IdUsu { get; set; } = null!;

    public string ContraUsu { get; set; } = null!;

    public string? NomCli { get; set; }

    public string? ApeCli { get; set; }

    public string? DniCli { get; set; }

    public string TlfCli { get; set; } = null!;

    public string? CorreoCli { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<TbFactura> TbFacturas { get; set; } = new List<TbFactura>();
}
