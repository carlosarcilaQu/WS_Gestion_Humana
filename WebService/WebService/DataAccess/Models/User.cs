using BlazorServer.DataAccess.Models.BaseEntity;

namespace DataAccess.Models;

public partial class User : BaseEntity<long>
{
    public long Id { get; set; }

    public long Document { get; set; }

    public string UserName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual ICollection<Datum> Data { get; set; } = new List<Datum>();
}
