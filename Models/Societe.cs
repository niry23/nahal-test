using System.Linq;

namespace NahalTest.Models {

    public class Societe : Entreprise {

        public string RaisonSocial {get; set;}
        public int CapitalSocial {get; set;}
        public int NombreParts { get; set; }
        public FormeJuridique FormeJuridique { get; set; }
    }
}