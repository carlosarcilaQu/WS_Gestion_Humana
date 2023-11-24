using BlazorServer.DataAccess.Models.BaseEntity;

namespace DataAccess.Models;

public partial class KactusRole : BaseEntity<long>
{
    public long Id { get; set; }

    public string RoleName { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual ICollection<ContributionRole> ContributionRoles { get; set; } = new List<ContributionRole>();
}
