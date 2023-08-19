using Microsoft.EntityFrameworkCore;

namespace Fabi.Core.Entities.Models;

[Owned]
public partial class RefreshToken
{
    public Guid Id { get; set; }
    public Guid ApplicationUserId { get; set; }
    #region Props
    public string Token { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresOn { get; set; } = DateTime.UtcNow.AddDays(10);
    public DateTime? RevokedOn { get; set; }
    #endregion

    #region Methods
    public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
    public bool IsActive => RevokedOn == null && !IsExpired;
    #endregion
}
