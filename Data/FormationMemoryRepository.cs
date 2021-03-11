using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Data
{ 
    public class FormationMemoryRepository : IFormationRepository
    {
        private List<Formation> _formations = new List<Formation>();
        public FormationMemoryRepository()
        {
            _formations.Add(new Formation { Id = 1, Nom = "Créer votre site web avec ASP.NET Core", NomSeo = "asp-net-core", Description = "Grace à cette formation j'ai decouvert le .NET Core"});
            _formations.Add(new Formation { Id = 2, Nom = "Créer votre site web avec PHP", NomSeo = "php", Description = "Grace à cette formation j'ai decouvert le PHP" });
            _formations.Add(new Formation { Id = 3, Nom = "Devenez un pros du jardin", NomSeo = "pros du jardin", Description = "Apprenez à faire du jardin" });
            _formations.Add(new Formation { Id = 4, Nom = "Phot Pro", NomSeo = "photo pro", Description = "un pros de la photo!" });
        }

        public List<Formation> GetFormations(int nombre)
        {
            return _formations.OrderBy(qu => Guid.NewGuid()).Take(nombre).ToList();
        }

        public List<Formation> GetAllFormations()
        {
            return _formations;
        }

        public Formation GetFormationById(int iIdFormation)
        {
           
            return _formations.FirstOrDefault(f => f.Id == iIdFormation);
        }

        public Formation GetFormationByNomSeo(string nomSeo)
        {
            return null;
        }

    }
}
