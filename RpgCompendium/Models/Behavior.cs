using System.Collections.Generic;

namespace RpgCompendium.Models
{
  public class Behavior
  {
    public Behavior()
    {
      this.Monsters = new HashSet<MonsterBehavior>();
    }
    public int BehaviorId { get; set; }
    public string BehaviorName { get; set; }
    public string BehaviorDescription { get; set; }
    public virtual ICollection<MonsterBehavior> Monsters { get; set; }

  }
}