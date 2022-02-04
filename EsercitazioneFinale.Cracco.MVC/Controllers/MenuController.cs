using EsercitazioneFinale.Cracco.Core.Entities;
using EsercitazioneFinale.Cracco.Core.Interfaces;
using EsercitazioneFinale.Cracco.MVC.Mapping;
using EsercitazioneFinale.Cracco.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EsercitazioneFinale.Cracco.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IBusinessLayer BL;

        public MenuController(IBusinessLayer bL)
        {
            BL = bL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Menu> menu = BL.GetAllMenu();
            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();
            foreach(var item in menu)
            {
                menuViewModel.Add(item.ToMenuViewModel());
            }
            return View(menuViewModel);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var menu = BL.GetMenuById(id);
            var piatti = menu.Piatti.ToList();
            var piattiViewModel = new List<PiattoViewModel>();
            double PrezzoTotale = 0;
            foreach (var item in piatti)
            {
                piattiViewModel.Add(item.ToPiattoViewModel());
                PrezzoTotale += item.Prezzo;
            }
            ViewBag.PrezzoTotale=PrezzoTotale;
            ViewBag.NomeMenu = menu.Nome;
            return View(piattiViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MenuViewModel menuViewModel)
        {
            if(ModelState.IsValid)
            {
                Menu menu = menuViewModel.ToMenu();
                Esito esito = BL.AddMenu(menu);
                if (esito.IsOK)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.ErrorMex = esito.Mex;
                    return View("BusinessError");
                }
            }
            return View(menuViewModel);
        }
    }
}
