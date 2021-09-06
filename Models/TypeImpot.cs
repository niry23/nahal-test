
using System.ComponentModel;

namespace NahalTest.Models
{
    public enum TypeImpot
    {
        [Description("Impôt sur la Société Réel Simplifié")]
        ISRS = 1,
        [Description("Impôt surla Société Réel Normal")]
        ISRN = 2,
        [Description("Impôt sur le Revenu Réel Simplifié")]
        IRRS = 3,
        [Description("Impôt sur le Revenu Réel Normal")]
        IRRN = 4
    }
}