using System;
using NahalTest.Models;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace NahalTest.Entreprises
{

    class Entreprises : IEntreprises
    {
        private EntrepriseContext _context;
        public Entreprises(EntrepriseContext context)
        {
            _context = context;
        }
        public void AddEntreprise(dynamic entreprise)
        {
            _context.Add(entreprise);
            _context.SaveChanges();
        }

        public void DeleteEntreprise(int id)
        {

            if (_context.Societes.SingleOrDefault(x => x.Id == id) != null)
            {
                _context.Societes.Remove(_context.Societes.SingleOrDefault(x => x.Id == id));
                _context.SaveChanges();
            }
            else if (_context.Individuelles.SingleOrDefault(x => x.Id == id) != null)
            {
                _context.Individuelles.Remove(_context.Individuelles.SingleOrDefault(x => x.Id == id));
                _context.SaveChanges();
            }
            else
                throw new Exception("Entreprise Introuvable !! ");
        }

        public void EditEntreprise(int id, JObject json)
        {
            if (json.Value<String>("Type") == "SA")
            {
                var newentreprise = json.ToObject<Individuelle>();
                var oldentreprise = _context.Individuelles.SingleOrDefault(x => x.Id == id);
                if (oldentreprise != null)
                {
                    oldentreprise.CodeNaf = newentreprise.CodeNaf != null ? newentreprise.CodeNaf : oldentreprise.CodeNaf;
                    oldentreprise.Email = newentreprise.Email != null ? newentreprise.Email : oldentreprise.Email;
                    oldentreprise.Impot = newentreprise.Impot  != 0 ? newentreprise.Impot : oldentreprise.Impot;
                    oldentreprise.Nom = newentreprise.Nom != null ? newentreprise.Nom : oldentreprise.Nom;
                    oldentreprise.NomCommercial = newentreprise.NomCommercial != null ? newentreprise.NomCommercial : oldentreprise.NomCommercial;
                    oldentreprise.Prenom = newentreprise.Prenom != null ? newentreprise.Prenom : oldentreprise.Prenom;
                    oldentreprise.Siret = newentreprise.Siret != null ? newentreprise.Siret : oldentreprise.Siret;
                    _context.SaveChanges();
                } else throw new Exception("Entreprise individuelle id = " + id + " introuvable");


            }
            else if (json.Value<String>("Type") == "SARL")
            {
                var newentreprise = json.ToObject<Societe>();
                var oldentreprise = _context.Societes.SingleOrDefault(x => x.Id == id);

                if(oldentreprise != null) {
                    oldentreprise.CodeNaf = newentreprise.CodeNaf != null ? newentreprise.CodeNaf : oldentreprise.CodeNaf;
                    oldentreprise.CapitalSocial = newentreprise.CapitalSocial != 0 ? newentreprise.CapitalSocial : oldentreprise.CapitalSocial;
                    oldentreprise.Email = newentreprise.Email != null ? newentreprise.Email : oldentreprise.Email;
                    oldentreprise.FormeJuridique = newentreprise.FormeJuridique != 0 ? newentreprise.FormeJuridique : oldentreprise.FormeJuridique;
                    oldentreprise.Impot = newentreprise.Impot != 0 ? newentreprise.Impot : oldentreprise.Impot;
                    oldentreprise.NombreParts = newentreprise.NombreParts != 0 ? newentreprise.NombreParts : oldentreprise.NombreParts;
                    oldentreprise.NomCommercial = newentreprise.NomCommercial != null ? newentreprise.NomCommercial : oldentreprise.NomCommercial;
                    oldentreprise.RaisonSocial = newentreprise.RaisonSocial != null ? newentreprise.RaisonSocial : oldentreprise.RaisonSocial;
                    oldentreprise.Siret = newentreprise.Siret != null ? newentreprise.Siret : oldentreprise.Siret;
                    _context.SaveChanges();
                } else throw new Exception("Entreprise sociéte id = " + id + " introuvable");
            }
            else throw new Exception("Veuillez préciser le type de l'entreprise svp!!");
        }

        public Entreprise GetEntreprise(int id)
        {
            if (_context.Societes.SingleOrDefault(x => x.Id == id) != null)
            {
                return _context.Societes.SingleOrDefault(x => x.Id == id);
            }
            else if (_context.Individuelles.SingleOrDefault(x => x.Id == id) != null)
            {
                return _context.Individuelles.SingleOrDefault(x => x.Id == id);
            }
            else
                throw new Exception("Entreprise Introuvable !! ");
        }
    }

}