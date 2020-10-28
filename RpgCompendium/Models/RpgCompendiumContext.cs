using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RpgCompendium.Models
{
  public class RpgCompendiumContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Monster> Monsters { get; set; }
    public DbSet<MainType> MainTypes { get; set; }
    public DbSet<Behavior> Behaviors { get; set; }
    public DbSet<Armor> Armors { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<ItemProperty> ItemProperties { get; set; }
    public DbSet<MonsterMainType> MonsterMainTypes { get; set; }
    public DbSet<MonsterBehavior> MonsterBehaviors { get; set; }
    public DbSet<MonsterArmor> MonsterArmors { get; set; }
    public DbSet<MonsterWeapon> MonsterWeapons { get; set; }
    public DbSet<ItemPropertyJoin> ItemPropertyJoins { get; set; } 

    public RpgCompendiumContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}