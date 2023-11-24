using BlazorServer.DataAccess.Models.BaseEntity;

namespace DataAccess.Models;

public partial class CheckCode : BaseEntity<long>
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public long Document { get; set; }

    public bool? Active { get; set; }

    public DateTime RegisterDate { get; set; }
}
