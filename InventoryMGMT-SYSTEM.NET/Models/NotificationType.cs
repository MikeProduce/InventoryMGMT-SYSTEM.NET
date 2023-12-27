using System;
using System.Collections.Generic;

namespace InventoryMGMT_SYSTEM.NET.Models;

public partial class NotificationType
{
    public int NotificationTypeId { get; set; }

    public string? NotificationTypeName { get; set; }

    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();
}
