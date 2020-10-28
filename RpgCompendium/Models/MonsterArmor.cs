namespace RpgCompendium.Models
{
  public class MonsterArmor
  {
    public int MonsterArmorId { get; set; }
    public int MonsterId { get; set; }
    public int ArmorId { get; set; }
    // public string ArmorSlot { get; set; }
    public virtual Monster Monster { get; set; }
    public virtual Armor Armor { get; set; }
  }
}