using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvisFormationCore.WebUi.Models;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormationCore.WebUi.Controllers
{
    public class AvisController : Controller
    {

        IFormationRepository _repository;
        IAvisRepository _avisRepository;
        UserManager<IdentityUser> _userManager;
        public AvisController(IFormationRepository repository, IAvisRepository avisRepository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _avisRepository = avisRepository;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult LaisserUnAvis(string idFormation)
        {
            int iIdFormation = -1;
            if (!Int32.TryParse(idFormation, out iIdFormation))
            {
                return RedirectToAction("ToutesLesFormations", "Formation");
            }

            var formation = _repository.GetFormationById(iIdFormation);

            if (formation == null)
            {
                return RedirectToAction("ToutesLesFormations", "Formation");
            }

            var vm = new LaisserUnAvisViewModel();
            vm.NomFormation = formation.Nom;
            vm.IdFormation = formation.Id.ToString();

            return View(vm);
        }
        [Authorize]
        public IActionResult SaveComment(LaisserUnAvisViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("LaisserUnAvis", viewModel);
            }

            if (String.IsNullOrEmpty(viewModel.Note))
            {
                return RedirectToAction("LaisserUnAvis", new { idFormation = viewModel.IdFormation });

            }

            var currentUser = this.User;
            var userName = _userManager.GetUserName(currentUser);

            _avisRepository.SaveAvis(viewModel.Commentaire, userName, viewModel.IdFormation, viewModel.Note);


            int iIdFormation = Int32.Parse(viewModel.IdFormation);

            var formation = _repository.GetFormationById(iIdFormation);

            return RedirectToAction("DetailsFormation", "Formation", new { nomSeo = formation.NomSeo });
        }


    }
}