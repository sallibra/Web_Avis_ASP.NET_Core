using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvisFormationCore.WebUi.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormationCore.WebUi.Controllers
{
    public class ContactController : Controller
    {
        IContactRepository _context;
        public ContactController(IContactRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new ContactViewModel();
            return View(vm);

        }

        public IActionResult SaveMessage(ContactViewModel viewModel)
        {
            if (!ModelState.IsValid /*|| String.IsNullOrEmpty(viewModel.Message) || String.IsNullOrEmpty(viewModel.Email)*/)
            {
                return View("Index", viewModel);
            }

            _context.SaveMessage(viewModel.Nom, viewModel.Email, viewModel.Message);

            return View();
        }

    }
}