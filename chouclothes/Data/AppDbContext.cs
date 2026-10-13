using Microsoft.EntityFrameworkCore;
using chouclothes.Models;

namespace chouclothes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // 告訴系統我們要為 ClothingItem 建立一個名叫 ClothingItems 的資料表
        public DbSet<ClothingItem> ClothingItems { get; set; }
    }
}