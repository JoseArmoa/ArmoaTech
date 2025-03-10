using System;
using System.Collections.Generic;

namespace ArmoaTechApi.Models;

public partial class Observaciones
{
    public int IdObservacion { get; set; }

    public string? CodReparacion { get; set; }

    public string? Detalle { get; set; }

    public string? Imgurl { get; set; }

    public virtual Reparaciones? CodReparacionNavigation { get; set; }
}
