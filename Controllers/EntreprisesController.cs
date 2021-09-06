using System;
using Microsoft.AspNetCore.Mvc;
using NahalTest.Entreprises;
using NahalTest.Models;
using Newtonsoft.Json.Linq;

namespace NahalTest.Controllers {


    
    [ApiController]
    public class EntreprisesController : ControllerBase {
        private IEntreprises _entreprises;

        public EntreprisesController (IEntreprises entreprises) {

            _entreprises = entreprises;
        }

        [HttpPost]
        [Route("company")]
        public IActionResult AddEntreprise (JObject json) {
            if(json.Value<String>("Type") == "SA") {
                _entreprises.AddEntreprise(json.ToObject<Individuelle>());
                return Ok("Ok");
            } else if(json.Value<String>("Type") == "SARL") {
                _entreprises.AddEntreprise(json.ToObject<Societe>());
                return Ok("Ok");
            }
            else
            return  BadRequest("Veuillez préciser un Type correcte!");
        }

        [HttpGet]
        [Route("company/{id}")]
        public IActionResult GetEntreprise (int id) {
            return Ok(_entreprises.GetEntreprise(id));
        }

        [HttpDelete]
        [Route("company/{id}")]
        public IActionResult DeleteEntreprise(int id) {
            _entreprises.DeleteEntreprise(id);
            return Ok("Ok");
        }

        [HttpPut]
        [Route("company/{id}")]
        public IActionResult UpdateEntreprise(int id, JObject json) {
            _entreprises.EditEntreprise(id,json);
            return Ok("ok");
        }

    
    }
}