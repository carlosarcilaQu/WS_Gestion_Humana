using BlazorServer.DataAccess.Models.BaseEntity;

namespace DataAccess.Models;

public partial class Table : BaseEntity<long>
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual ICollection<Datum> Data { get; set; } = new List<Datum>();
}
