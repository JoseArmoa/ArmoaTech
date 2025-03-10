using System;
using System.Collections.Generic;

namespace ArmoaTechApi.Models;

public partial class Marca
{
    public int IdMarcas { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
