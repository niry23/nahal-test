
using System.Linq;
namespace NahalTest.Models
{
    public abstract class Entreprise
    {


        public int Id { get; set; }
        public string NomCommercial { get; set; }
        public string CodeNaf { get; set; }
        public string Email { get; set; }
        public string Siret { get; set; }
        public TypeImpot Impot { get; set; }
    }

}
