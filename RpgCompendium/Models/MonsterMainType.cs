using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RpgCompendium.Models
{
  public class MonsterMainType
  {
    public int MonsterMainTypeId { get; set; }
    public int MonsterId { get; set; }
    public int MainTypeId { get; set; } 
    public virtual Monster Monster { get; set; }
    public virtual MainType MainType { get; set; }

    public static void Post(MonsterMainType monsterMainType)
    {
      string jsonMonsterMainType = JsonConvert.SerializeObject(monsterMainType);
      var apiCallTask = ApiHelper.Post("monsterMainTypes", jsonMonsterMainType);
    }
  }
}