using System.Collections.Generic;

namespace RpgCompendium.Models
{
  public class MainType
  {
    public MainType()
    {
      this.Monsters = new HashSet<MonsterMainType>();
    }
    public int MainTypeId { get; set; }
    public string MainTypeName { get; set; }
    public string MainTypeDescription { get; set; }
    public virtual ICollection<MonsterMainType> Monsters { get; set; }
  }
}