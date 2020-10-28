using Microsoft.AspNetCore.Mvc;
using RpgCompendium.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace RpgCompendium.Controllers
{
  [Authorize(Roles = "Administrator")]
  public class ArmorsController : Controller
  {
    private readonly RpgCompendiumContext _db;

    public ArmorsController(RpgCompendiumContext db)
    {
      _db = db;
    }
[AllowAnonymous]
    public ActionResult Index()
    {
      List<Armor> model = _db.Armors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Armor Armor)
    {      
      _db.Armors.Add(Armor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
[AllowAnonymous]
    public ActionResult Details(int id)
    {
      var thisArmor = _db.Armors
          // .Include(monster => monster.Monsters)
          // .ThenInclude(join => join.Monster)
          .FirstOrDefault(Armor => Armor.ArmorId == id);
      return View(thisArmor);
    }

    public ActionResult Edit(int id)
    {
      var thisArmor = _db.Armors.FirstOrDefault(Armor => Armor.ArmorId == id);
      return View(thisArmor);
    }

    [HttpPost]
    public ActionResult Edit(Armor Armor)
    {
      _db.Entry(Armor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisArmor = _db.Armors.FirstOrDefault(Armor => Armor.ArmorId == id);
      return View(thisArmor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisArmor = _db.Armors.FirstOrDefault(Armor => Armor.ArmorId == id);
      _db.Armors.Remove(thisArmor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    // MONSTERS
    public ActionResult AddMonster(int id)
    {
      var thisArmor = _db.Armors.FirstOrDefault(Armors => Armors.ArmorId == id);
      ViewBag.MonsterId = new SelectList(_db.Monsters, "MonsterId", "MonsterName");
      return View(thisArmor);
    }
    [HttpPost]
    public ActionResult AddMonster(Armor armor, int MonsterId)
    {
      if (MonsterId != 0)
      {
        _db.MonsterArmors.Add(new MonsterArmor() { MonsterId = MonsterId, ArmorId = armor.ArmorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = armor.ArmorId });
    }
    [HttpPost]
    public ActionResult DeleteMonster(int ArmorId, int joinId)
    {
      var joinEntry = _db.MonsterArmors.FirstOrDefault(entry => entry.MonsterArmorId == joinId);
      _db.MonsterArmors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = ArmorId });
    }

    // PROPERTIES

    public ActionResult AddItemProperty(int id)
    {
      var thisArmor = _db.Armors.FirstOrDefault(armors => armors.ArmorId == id);
      ViewBag.ItemPropertyId = new SelectList(_db.ItemProperties, "ItemPropertyId", "ItemPropertyName");
      return View(thisArmor);
    }
    [HttpPost]
    public ActionResult AddItemProperty(Armor armor, int ItemPropertyId)
    {
      if (ItemPropertyId != 0)
      {
        _db.ItemPropertyJoins.Add(new ItemPropertyJoin() { ItemPropertyId = ItemPropertyId, ArmorId = armor.ArmorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = armor.ArmorId });
    }
    [HttpPost]
    public ActionResult DeleteItemProperty(int ArmorId, int joinId)
    {
      var joinEntry = _db.ItemPropertyJoins.FirstOrDefault(entry => entry.ItemPropertyJoinId == joinId);
      _db.ItemPropertyJoins.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = ArmorId });
    }
  }
}