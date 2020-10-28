// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Identity;
// using RpgCompendium.Models;
// using System.Threading.Tasks;
using RpgCompendium.ViewModels;
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
  public class AccountController : Controller
  {
    private readonly RpgCompendiumContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RpgCompendiumContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      if(User.Identity.IsAuthenticated)
      {
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userMonsters = _db.Monsters.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userMonsters);
      }
      else
      {
        return View();
      }
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
          return RedirectToAction("Index");
      }
      else
      {
          return View();
      }
    }
    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index");
    }
    public async Task<ActionResult> Edit(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      if(User.Identity.IsAuthenticated)
      {
      var currentUser = await _userManager.FindByIdAsync(userId);
      return View(currentUser);
      }
      return View();
    }
    
    // [HttpPost]
    // public async Task<ActionResult> Edit(Monster monster)
    // {
    //   _db.Entry(monster).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Details", new { id = monster.MonsterId });

    //   // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //   // if(User.Identity.IsAuthenticated)
    //   // {
    //   // var currentUser = await _userManager.FindByIdAsync(userId);
    //   // var userMonsters = _db.Monsters.Where(entry => entry.User.Id == currentUser.Id).ToList();
    //   // return View(userMonsters);
    //   // }
    //   // else
    //   // {
    //   //   return View();
    //   // }
    // }
  }
}
