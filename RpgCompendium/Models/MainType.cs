using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    public static List<MainType> GetMainTypes()
    {
      var apiCallTask = ApiHelper.GetAll("mainTypes");
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<MainType> mainTypeList = JsonConvert.DeserializeObject<List<MainType>>(jsonResponse.ToString());

      return mainTypeList;
    }
  }
}