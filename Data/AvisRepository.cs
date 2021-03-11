using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Data
{
    public class AvisRepository : IAvisRepository
    {
        MonDbContext _context;
        public AvisRepository(MonDbContext context)
        {
            _context = context;
        }

        public void SaveAvis(string commentaire, string nom, string idFormation, string note)
        {
            int iIdFormation = -1;
            if(!Int32.TryParse(idFormation,out iIdFormation))
            {
                return;
            }
            double dNote = -1;
            if (!Double.TryParse(note, NumberStyles.Any, CultureInfo.InvariantCulture,out dNote))
            {
                return;
            }

            var avis = new Avis();
            avis.Commentaire = commentaire;
            avis.NomUtilisateur = nom;
            avis.FormationId = iIdFormation;
            avis.Note = dNote;

            _context.Avis.Add(avis);
            _context.SaveChanges();

            
        }
    }
}
