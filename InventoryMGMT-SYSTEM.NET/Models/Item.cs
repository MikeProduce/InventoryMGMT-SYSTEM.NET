using System;
using System.Collections.Generic;

namespace InventoryMGMT_SYSTEM.NET.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public string? ItemDetails { get; set; }

    public decimal? ItemCost { get; set; }

    public int? ItemTypeId { get; set; }

    public int? ItemStatusId { get; set; }

    public virtual Status? ItemStatus { get; set; }

    public virtual ItemType? ItemType { get; set; }

    public virtual ICollection<RentalOrder> RentalOrders { get; } = new List<RentalOrder>();
}
