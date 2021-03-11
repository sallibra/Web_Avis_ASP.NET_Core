using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AvisFormationCore.WebUi.Models;
using Data;

namespace AvisFormationCore.WebUi.Controllers
{
    public class HomeController : Controller
    {
        IFormationRepository _repository;
        public HomeController(IFormationRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(ToutesLesFormationsViewModel formations)
        {
            var listFormations = _repository.GetFormations(5);
            var vm = new List<DetailFormationViewModel>();
            foreach(var f in listFormations)
            {
                vm.Add(
                    new DetailFormationViewModel
                    {
                        Formation = f,
                        NoteMoyenne = f.Avis.Select(a => a.Note)
                        .DefaultIfEmpty(0).Average()
                    });
            }
            return View(vm);
        }
    }
}
