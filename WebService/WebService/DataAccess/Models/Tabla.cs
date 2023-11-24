using BlazorServer.DataAccess.Models.BaseEntity;

namespace DataAccess.Models;

public partial class Tabla : BaseEntity<long>
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Dato> Datos { get; set; } = new List<Dato>();
}
