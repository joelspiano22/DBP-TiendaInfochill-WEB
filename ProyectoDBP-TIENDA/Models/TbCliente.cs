using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbCliente
{
    public int CodCliente { get; set; }

    public string? NomCli { get; set; }

    public string? ApeCli { get; set; }

    public string? DniCli { get; set; }

    public string TlfCli { get; set; } = null!;

    public string? CorreoCli { get; set; }

    public byte? Estado { get; set; }
}
