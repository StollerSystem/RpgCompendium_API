using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RpgCompendium.Models
{
  public class Monster
  {
    public Monster()
    {      
      this.MainTypes = new HashSet<MonsterMainType>();
      this.Behaviors = new HashSet<MonsterBehavior>();
      this.Armors = new HashSet<MonsterArmor>();   
      this.Weapons = new HashSet<MonsterWeapon>();      
    }
    public int MonsterId { get; set; }
    public string MonsterName { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<MonsterMainType> MainTypes { get; set; }
    public virtual ICollection<MonsterBehavior> Behaviors { get; set; }
    public virtual ICollection<MonsterArmor> Armors { get; set; }
    public virtual ICollection<MonsterWeapon> Weapons { get; set; }

    public static List<Monster> GetMonsters()
    {
      var apiCallTask = ApiHelper.GetAll("monsters");
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Monster> monsterList = JsonConvert.DeserializeObject<List<Monster>>(jsonResponse.ToString());

      return monsterList;
    }

    public static void Post(Monster monster, int MainTypeId)
    {
      string jsonMonster = JsonConvert.SerializeObject(monster);
      var apiCallTask = ApiHelper.Post("monsters", jsonMonster, "MainTypeId", MainTypeId);
    }

    public static Monster GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id, "monsters");
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Monster monster = JsonConvert.DeserializeObject<Monster>(jsonResponse.ToString());

      return monster;
    }

  }
}

