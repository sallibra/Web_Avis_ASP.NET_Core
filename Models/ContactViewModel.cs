using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvisFormationCore.WebUi.Models
{
    public class ContactViewModel
    {
        [StringLength(20, ErrorMessage = "Le texte du commentaire dépasse la taille maximale autorisée")]
        public string Message { get; set; }

        public string Nom { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //public string NomFormation { get; set; }
        //public string IdFormation { get; set; }

    }
}
