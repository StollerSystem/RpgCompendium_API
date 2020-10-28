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
  public class WeaponsController : Controller
  {
    private readonly RpgCompendiumContext _db;

    public WeaponsController(RpgCompendiumContext db)
    {
      _db = db;
    }
    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Weapon> model = _db.Weapons.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Weapon Weapon)
    {      
      _db.Weapons.Add(Weapon);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var thisWeapon = _db.Weapons
          // .Include(monster => monster.Monsters)
          // .ThenInclude(join => join.Monster)
          .FirstOrDefault(Weapon => Weapon.WeaponId == id);
      return View(thisWeapon);
    }

    public ActionResult Edit(int id)
    {
      var thisWeapon = _db.Weapons.FirstOrDefault(Weapon => Weapon.WeaponId == id);
      return View(thisWeapon);
    }

    [HttpPost]
    public ActionResult Edit(Weapon Weapon)
    {
      _db.Entry(Weapon).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisWeapon = _db.Weapons.FirstOrDefault(Weapon => Weapon.WeaponId == id);
      return View(thisWeapon);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisWeapon = _db.Weapons.FirstOrDefault(Weapon => Weapon.WeaponId == id);
      _db.Weapons.Remove(thisWeapon);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    // MONSTERS
    public ActionResult AddMonster(int id)
    {
      var thisWeapon = _db.Weapons.FirstOrDefault(AWeapons => AWeapons.WeaponId == id);
      ViewBag.MonsterId = new SelectList(_db.Monsters, "MonsterId", "MonsterName");
      return View(thisWeapon);
    }
    [HttpPost]
    public ActionResult AddMonster(Weapon weapon, int MonsterId)
    {
      if (MonsterId != 0)
      {
        _db.MonsterWeapons.Add(new MonsterWeapon() { MonsterId = MonsterId, WeaponId = weapon.WeaponId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = weapon.WeaponId });
    }
    [HttpPost]
    public ActionResult DeleteMonster(int WeaponId, int joinId)
    {
      var joinEntry = _db.MonsterWeapons.FirstOrDefault(entry => entry.MonsterWeaponId == joinId);
      _db.MonsterWeapons.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = WeaponId });
    }

    // PROPERTIES

    public ActionResult AddItemProperty(int id)
    {
      var thisWeapon = _db.Weapons.FirstOrDefault(AWeapons => AWeapons.WeaponId == id);
      ViewBag.ItemPropertyId = new SelectList(_db.ItemProperties, "ItemPropertyId", "ItemPropertyName");
      return View(thisWeapon);
    }
    [HttpPost]
    public ActionResult AddItemProperty(Weapon weapon, int ItemPropertyId)
    {
      if (ItemPropertyId != 0)
      {
        _db.ItemPropertyJoins.Add(new ItemPropertyJoin() { ItemPropertyId = ItemPropertyId, WeaponId = weapon.WeaponId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = weapon.WeaponId });
    }
    [HttpPost]
    public ActionResult DeleteItemProperty(int WeaponId, int joinId)
    {
      var joinEntry = _db.ItemPropertyJoins.FirstOrDefault(entry => entry.ItemPropertyJoinId == joinId);
      _db.ItemPropertyJoins.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = WeaponId });
    }
  }
}