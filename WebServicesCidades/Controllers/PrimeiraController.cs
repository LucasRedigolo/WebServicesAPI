using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers {
    //Vamos definir a rota para a requisição do serviço
    public class PrimeiraController : Controller {
        Cidades cidade = new Cidades ();
        DAOCidades dao = new DAOCidades ();

        [HttpGet]
        [Route ("api/GetAll")]
        public IEnumerable<Cidades> Get () {
            return dao.Listar ();
        }

        [HttpGet ("{ID}", Name = "CidadeAtual")]
        [Route ("api/GetAll/{ID}")]
        public Cidades Get (int id) {
            return dao.Listar ().Where (x => x.ID == id).FirstOrDefault ();
        }

        [HttpPost]
        [Route ("api/AddCity")]
        public IActionResult Post ([FromBody] Cidades cidades) {
            dao.Cadastro (cidades);
            return CreatedAtRoute ("CidadeAtual", new { id = cidades.ID }, cidades);
        }
    }
}