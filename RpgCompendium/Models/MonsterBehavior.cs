namespace RpgCompendium.Models
{
  public class MonsterBehavior
  {
    public int MonsterBehaviorId { get; set; }
    public int MonsterId { get; set; }
    public int BehaviorId { get; set; }
    public virtual Monster Monster { get; set; }
    public virtual Behavior Behavior { get; set; }
  }
}