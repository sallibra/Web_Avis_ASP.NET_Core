using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvisFormationCore.WebUi.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormationCore.WebUi.Controllers
{
    public class FormationController : Controller
    {
        IFormationRepository _repository;
        public FormationController(IFormationRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var vm = new ToutesLesFormationsViewModel();
            vm.Message = "Ceci est un message du controlleur";
            vm.Nombre = 93;

            return View(vm);
        }

        public IActionResult ToutesLesFormations()
        {
            var listFormation = _repository.GetAllFormations();

            return View(listFormation);
        }

        public IActionResult DetailsFormation(string nomSeo)
        {

            var formation = _repository.GetFormationByNomSeo(nomSeo);

            if(formation == null)
            {
                return RedirectToAction("ToutesLesFormations");
            }

            var vm = new DetailFormationViewModel();
            vm.Formation = formation;
            if (formation.Avis != null && formation.Avis.Count > 0)
                vm.NoteMoyenne = formation.Avis.Select(a => a.Note).ToList().Average();


            return View(vm);
        }
    }
}