using System;
using System.Collections.Generic;

namespace DL;

public partial class Restaurante
{
    public int IdRestaurante { get; set; }

    public string? Nombre { get; set; }

    public int? CantidadEmpleados { get; set; }

    public int? CapacidadClientes { get; set; }

    public string? FechaInauguracion { get; set; }

    public decimal? Calificacion { get; set; }
}
