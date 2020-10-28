namespace RpgCompendium.Models
{
  public class MonsterWeapon
  {
    public int MonsterWeaponId { get; set; }
    public int MonsterId { get; set; }
    public int WeaponId { get; set; }   
    public string WeaponSlot { get; set; }    
    public virtual Monster Monster { get; set; }
    public virtual Weapon Weapon { get; set; }
  }
}