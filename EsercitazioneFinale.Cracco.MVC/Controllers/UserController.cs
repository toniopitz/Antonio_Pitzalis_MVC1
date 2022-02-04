using EsercitazioneFinale.Cracco.Core.Interfaces;
using EsercitazioneFinale.Cracco.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EsercitazioneFinale.Cracco.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IBusinessLayer BL;
        public UserController(IBusinessLayer bl)
        {
            BL = bl;  
        }
        public IActionResult Login(string returnUrl="/")
        {
            return View(new UserViewModel { ReturnUrl=returnUrl});
        }
    }
}
