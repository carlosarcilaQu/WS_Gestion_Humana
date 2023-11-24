using BlazorServer.DataAccess.Models.BaseEntity;

namespace DataAccess.Models;

public partial class Contribution : BaseEntity<long>
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Document { get; set; }

    public string Role { get; set; } = null!;

    public long HeadquartersId { get; set; }

    public string CostCenter { get; set; } = null!;

    public long ContributionRoleId { get; set; }

    public bool? Active { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual ContributionRole ContributionRole { get; set; } = null!;

    public virtual Datum Headquarters { get; set; } = null!;
}
