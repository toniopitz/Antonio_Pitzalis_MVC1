using EsercitazioneFinale.Cracco.Core.Entities;
using EsercitazioneFinale.Cracco.Core.Interfaces;
using EsercitazioneFinale.Cracco.MVC.Mapping;
using EsercitazioneFinale.Cracco.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static EsercitazioneFinale.Cracco.Core.Entities.Piatto;

namespace EsercitazioneFinale.Cracco.MVC.Controllers
{
    public class PiattiController : Controller
    {
        private readonly IBusinessLayer BL;

        public PiattiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            var piatti = BL.GetAllPiatti();
            List<PiattoViewModel> piattoViewModel = new List<PiattoViewModel>();
            foreach (var piatto in piatti)
            {
                piattoViewModel.Add(piatto.ToPiattoViewModel());
            }
            return View(piattoViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PiattoViewModel piattoViewModel)
        {
            if(ModelState.IsValid)
            {
                //Assegnazione dell'id tramite il nome del menu inserito dall'utente
                var menu = BL.GetAllMenu().FirstOrDefault(m=>m.Nome == piattoViewModel.Menu.Nome);
                piattoViewModel.MenuId = menu.Id;

                var piatto = piattoViewModel.ToPiatto();
                var esito = BL.AddPiatto(piatto);
                if(esito.IsOK)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErroMex = esito.Mex;
                    return View("BusinessError");
                }
            }
            
            return View(piattoViewModel);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
           
            var piatto = BL.GetPiattoById(id);
            var piattoViewModel = piatto.ToPiattoViewModel();
            return View(piattoViewModel);
        }
        [HttpPost]
        public IActionResult Update(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                //Assegnazione dell'id tramite il nome del menu inserito dall'utente
                var menu = BL.GetAllMenu().FirstOrDefault(m => m.Nome == piattoViewModel.Menu.Nome);
                piattoViewModel.MenuId = menu.Id;
               
                var piatto = piattoViewModel.ToPiatto();
                var esito = BL.UpdatePiatto(piatto);
                if (esito.IsOK)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErroMex = esito.Mex;
                    return View("BusinessError");
                }
            }
            
            return View(piattoViewModel);
        }
        [HttpGet]
        public IActionResult Delete(PiattoViewModel piattoViewModel)
        {
            var piatto = piattoViewModel.ToPiatto();
            var esito = BL.DeletePiatto(piatto.Id);
            if (esito.IsOK)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ErrorMessage = esito.Mex;
                return View("BusinessError");
            }
        }
    }
}
