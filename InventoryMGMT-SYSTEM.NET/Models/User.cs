using System;
using System.Collections.Generic;

namespace InventoryMGMT_SYSTEM.NET.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? UserType { get; set; }

    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();

    public virtual ICollection<RentalOrder> RentalOrders { get; } = new List<RentalOrder>();
}
