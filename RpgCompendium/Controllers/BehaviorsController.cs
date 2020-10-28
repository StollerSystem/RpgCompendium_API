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
  public class BehaviorsController : Controller
  {
    private readonly RpgCompendiumContext _db;

    public BehaviorsController(RpgCompendiumContext db)
    {
      _db = db;
    }

  [AllowAnonymous]
    public ActionResult Index()
    {
      List<Behavior> model = _db.Behaviors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Behavior behavior)
    {
      _db.Behaviors.Add(behavior);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var thisBehavior = _db.Behaviors
          // .Include(monster => monster.Monsters)
          // .ThenInclude(join => join.Monster)
          .FirstOrDefault(behavior => behavior.BehaviorId == id);
      return View(thisBehavior);
    }

    public ActionResult Edit(int id)
    {
      var thisBehavior = _db.Behaviors.FirstOrDefault(behavior => behavior.BehaviorId == id);
      return View(thisBehavior);
    }

    [HttpPost]
    public ActionResult Edit(Behavior behavior)
    {
      _db.Entry(behavior).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisBehavior = _db.Behaviors.FirstOrDefault(behavior => behavior.BehaviorId == id);
      return View(thisBehavior);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBehavior = _db.Behaviors.FirstOrDefault(behavior => behavior.BehaviorId == id);
      _db.Behaviors.Remove(thisBehavior);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    // MONSTERS
    public ActionResult AddMonster(int id)
    {
      var thisBehavior = _db.Behaviors.FirstOrDefault(behaviors => behaviors.BehaviorId == id);
      ViewBag.MonsterId = new SelectList(_db.Monsters, "MonsterId", "MonsterName");
      return View(thisBehavior);
    }
    [HttpPost]
    public ActionResult AddMonster(Behavior behavior, int MonsterId)
    {
      if (MonsterId != 0)
      {
        _db.MonsterBehaviors.Add(new MonsterBehavior() { MonsterId = MonsterId, BehaviorId = behavior.BehaviorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = behavior.BehaviorId });
    }
    [HttpPost]
    public ActionResult DeleteMonster(int behaviorId, int joinId)
    {
      var joinEntry = _db.MonsterBehaviors.FirstOrDefault(entry => entry.MonsterBehaviorId == joinId);
      _db.MonsterBehaviors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = behaviorId });
    }
  }
}