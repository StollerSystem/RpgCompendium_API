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
  public class ItemPropertiesController : Controller
  {
    private readonly RpgCompendiumContext _db;

    public ItemPropertiesController(RpgCompendiumContext db)
    {
      _db = db;
    }
    [AllowAnonymous]
    public ActionResult Index()
    {
      List<ItemProperty> model = _db.ItemProperties.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(ItemProperty ItemProperty)
    {      
      _db.ItemProperties.Add(ItemProperty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var thisItemProperty = _db.ItemProperties
        .FirstOrDefault(ItemProperty => ItemProperty.ItemPropertyId == id);
      return View(thisItemProperty);
    }

    public ActionResult Edit(int id)
    {
      var thisItemProperty = _db.ItemProperties.FirstOrDefault(ItemProperty => ItemProperty.ItemPropertyId == id);
      return View(thisItemProperty);
    }

    [HttpPost]
    public ActionResult Edit(ItemProperty ItemProperty)
    {
      _db.Entry(ItemProperty).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisItemProperty = _db.ItemProperties.FirstOrDefault(ItemProperty => ItemProperty.ItemPropertyId == id);
      return View(thisItemProperty);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisItemProperty = _db.ItemProperties.FirstOrDefault(ItemProperty => ItemProperty.ItemPropertyId == id);
      _db.ItemProperties.Remove(thisItemProperty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult AddItem(int id)
    {
      var thisProperty = _db.ItemProperties.FirstOrDefault(property => property.ItemPropertyId == id);
      ViewBag.ArmorId = new SelectList(_db.Armors, "ArmorId", "ArmorName");
      ViewBag.WeaponId = new SelectList(_db.Weapons, "WeaponId", "WeaponName");
      return View(thisProperty);
    }

    [HttpPost]
    public ActionResult AddItem(ItemProperty itemProperty, int ArmorId, int WeaponId)
    {
      if (ArmorId != 0)
      {
        _db.ItemPropertyJoins.Add(new ItemPropertyJoin() { ArmorId = ArmorId, ItemPropertyId = itemProperty.ItemPropertyId });
      }

      if (WeaponId != 0)
      {
        _db.ItemPropertyJoins.Add(new ItemPropertyJoin() { WeaponId = WeaponId, ItemPropertyId = itemProperty.ItemPropertyId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = itemProperty.ItemPropertyId });
    }

    [HttpPost]
    public ActionResult DeleteItem(int ItemPropertyId, int joinId)
    {
      var joinEntry = _db.ItemPropertyJoins.FirstOrDefault(entry => entry.ItemPropertyJoinId == joinId);
      _db.ItemPropertyJoins.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = ItemPropertyId });
    }
  }
}