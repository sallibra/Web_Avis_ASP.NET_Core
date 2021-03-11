using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class FormationRepository : IFormationRepository
    {
        MonDbContext _context;

        public FormationRepository(MonDbContext context)
        {
            _context = context;
        }

        public List<Formation> GetFormations(int nombre)
        {
            return _context.Formations.Include("Avis").OrderBy(qu => Guid.NewGuid()).Take(nombre).ToList();
        }

        public List<Formation> GetAllFormations()
        {
            return _context.Formations.ToList();
        }

        public Formation GetFormationById(int iIdFormation)
        {
            return _context.Formations.Include("Avis").FirstOrDefault(f => f.Id == iIdFormation);

        }

        public Formation GetFormationByNomSeo(string nomSeo)
        {
            return _context.Formations.Include("Avis").FirstOrDefault(f => f.NomSeo == nomSeo);

        }
    }
}
