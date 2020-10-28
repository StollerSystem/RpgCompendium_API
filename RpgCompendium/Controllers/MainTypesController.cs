using Microsoft.AspNetCore.Mvc;
using RpgCompendium.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RpgCompendium.Controllers
{
  public class MainTypesController : Controller
  {
    private readonly RpgCompendiumContext _db;

    public MainTypesController(RpgCompendiumContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      var allMainTypes = MainType.GetMainTypes();
      // List<MainType> model = _db.MainTypes.ToList();
      return View(allMainTypes);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(MainType mainType)
    {
      _db.MainTypes.Add(mainType);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMainType = _db.MainTypes
          // .Include(mainType => mainType.MainTypes)
          // .ThenInclude(join => join.Monster)
          .FirstOrDefault(mainType => mainType.MainTypeId == id);
      return View(thisMainType);
    }

    public ActionResult Edit(int id)
    {
      var thisMainType = _db.MainTypes.FirstOrDefault(mainType => mainType.MainTypeId == id);
      return View(thisMainType);
    }

    [HttpPost]
    public ActionResult Edit(MainType mainType)
    {
      _db.Entry(mainType).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mainType.MainTypeId });
    }

    public ActionResult Delete(int id)
    {
      var thisMainType = _db.MainTypes.FirstOrDefault(mainType => mainType.MainTypeId == id);
      return View(thisMainType);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMainType = _db.MainTypes.FirstOrDefault(mainType => mainType.MainTypeId == id);
      _db.MainTypes.Remove(thisMainType);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMonster(int id)
    {
      var thisMainType = _db.MainTypes.FirstOrDefault(mainTypes => mainTypes.MainTypeId == id);
      ViewBag.MonsterId = new SelectList(_db.Monsters, "MonsterId", "MonsterName");
      return View(thisMainType);
    }
    [HttpPost]
    public ActionResult AddMonster(MainType mainType, int MonsterId)
    {
      if (MonsterId != 0)
      {
        _db.MonsterMainTypes.Add(new MonsterMainType() { MonsterId = MonsterId, MainTypeId = mainType.MainTypeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mainType.MainTypeId });
    }
    [HttpPost]
    public ActionResult DeleteMonster(int mainTypeId, int joinId)
    {
      var joinEntry = _db.MonsterMainTypes.FirstOrDefault(entry => entry.MonsterMainTypeId == joinId);
      _db.MonsterMainTypes.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mainTypeId });
    }
  }
}