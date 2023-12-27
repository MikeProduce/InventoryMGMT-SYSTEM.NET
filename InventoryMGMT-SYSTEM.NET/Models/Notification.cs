using System;
using System.Collections.Generic;

namespace InventoryMGMT_SYSTEM.NET.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int? UserId { get; set; }

    public int? RentalOrderId { get; set; }

    public int? NotificationTypeId { get; set; }

    public DateTime? NotificationDate { get; set; }

    public virtual NotificationType? NotificationType { get; set; }

    public virtual RentalOrder? RentalOrder { get; set; }

    public virtual User? User { get; set; }
}
