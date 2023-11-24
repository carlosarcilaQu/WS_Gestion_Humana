using BlazorServer.DataAccess.Models.BaseEntity;

namespace DataAccess.Models;

public partial class Datum : BaseEntity<long>
{
    public long Id { get; set; }

    public long? ParentId { get; set; }

    public long TableId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public long Value { get; set; }

    public string? Equivalent { get; set; }

    public string? Inheritance { get; set; }

    public bool? Active { get; set; }

    public DateTime RegisterDate { get; set; }

    public long UserId { get; set; }

    public virtual ICollection<Contribution> Contributions { get; set; } = new List<Contribution>();

    public virtual ICollection<Datum> InverseParent { get; set; } = new List<Datum>();

    public virtual Datum? Parent { get; set; }

    public virtual Table Table { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
