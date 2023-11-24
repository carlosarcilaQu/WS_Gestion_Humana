using BlazorServer.DataAccess.Models.BaseEntity;

namespace DataAccess.Models;

public partial class ContributionRole : BaseEntity<long>
{
    public long Id { get; set; }

    public long KactusRoleId { get; set; }

    public long Value { get; set; }

    public bool? Active { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual ICollection<Contribution> Contributions { get; set; } = new List<Contribution>();

    public virtual KactusRole KactusRole { get; set; } = null!;
}
