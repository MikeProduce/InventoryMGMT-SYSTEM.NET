using System;
using System.Collections.Generic;

namespace InventoryMGMT_SYSTEM.NET.Models;

public partial class ItemType
{
    public int ItemTypeId { get; set; }

    public string? ItemTypeName { get; set; }

    public virtual ICollection<Item> Items { get; } = new List<Item>();
}
