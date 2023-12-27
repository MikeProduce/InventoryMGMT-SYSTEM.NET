using Microsoft.EntityFrameworkCore;

namespace InventoryMGMT_SYSTEM.NET.Data
{
    public class InventoryMGMTDbContext: DbContext
    {
        public InventoryMGMTDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
        // where the tables would go
    }
}
