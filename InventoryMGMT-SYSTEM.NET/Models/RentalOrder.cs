using System;
using System.Collections.Generic;

namespace InventoryMGMT_SYSTEM.NET.Models;

public partial class RentalOrder
{
    public int RentalOrderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? TotalCost { get; set; }

    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();

    public virtual User? User { get; set; }

    public virtual ICollection<Item> Items { get; } = new List<Item>();
}
