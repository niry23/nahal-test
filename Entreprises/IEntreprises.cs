using System;
using System.Collections.Generic;
using NahalTest.Models;
using Newtonsoft.Json.Linq;

namespace NahalTest.Entreprises {

    public interface IEntreprises
    {
        Entreprise GetEntreprise(int id);
        void AddEntreprise(dynamic entreprise);
        void DeleteEntreprise(int id);
        void EditEntreprise(int id, JObject entreprise);
    }
}