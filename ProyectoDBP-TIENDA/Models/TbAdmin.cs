using System;
using System.Collections.Generic;

namespace ProyectoDBP_TIENDA.Models;

public partial class TbAdmin
{
    public int IdAdmin { get; set; }

    public string CodAdmin { get; set; } = null!;

    public string PassAdmin { get; set; } = null!;
}
