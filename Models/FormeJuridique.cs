using System.ComponentModel;

namespace NahalTest.Models
{
    public enum FormeJuridique
    {
        [Description("Société Anonyme")]
        SA = 1,
        [Description("Société Actions Symplifiées")]
        SAS = 2,
        [Description("Société Actions Symplifiées Unipersonelle")]
        SASU = 3
    }
}