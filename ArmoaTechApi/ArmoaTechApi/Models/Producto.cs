using System;
using System.Collections.Generic;

namespace ArmoaTechApi.Models;

public partial class Producto
{
    public string CodProducto { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdMarca { get; set; }

    public decimal? Precio { get; set; }

    public string? Imageurl { get; set; }

    public bool? Estado { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
}
