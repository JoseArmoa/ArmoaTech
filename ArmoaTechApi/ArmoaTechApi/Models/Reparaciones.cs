using System;
using System.Collections.Generic;

namespace ArmoaTechApi.Models;

public partial class Reparaciones
{
    public string CodReparacion { get; set; } = null!;

    public string NombreCliente { get; set; } = null!;

    public string? TelefonoCliente { get; set; }

    public string? EmailCliente { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public DateOnly? FechaRetiro { get; set; }

    public string Servicio { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string? Ubicacion { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<Observaciones>? Observaciones { get; set; } = new List<Observaciones>();
}
