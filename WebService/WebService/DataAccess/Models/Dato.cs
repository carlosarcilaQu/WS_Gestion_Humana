using BlazorServer.DataAccess.Models.BaseEntity;
using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Dato : BaseEntity<long>
{
    public long Id { get; set; }

    public long TablaId { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public long Valor { get; set; }

    public int Orden { get; set; }

    public long? PadreId { get; set; }

    public string? Equivalente { get; set; }

    public string? Herencia { get; set; }

    public DateTime FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public long? UsuarioId { get; set; }

    public virtual Tabla Tabla { get; set; } = null!;
}
