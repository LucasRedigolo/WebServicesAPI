using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;

namespace WebServicesCidades.Controllers {
    //Vamos definir a rota para a requisição do serviço
    [Route ("api/[controller]")]
    public class PrimeiraController : Controller {
        Cidades cidade = new Cidades ();
        DAOCidades dao = new DAOCidades();

        [HttpGet]
        public IEnumerable<Cidades> Get () {
            return dao.Listar();
        }

        [HttpGet("{ID}", Name = "CidadeAtual")]
        public Cidades Get(int id){
            return dao.Listar().Where(x => x.ID==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cidades cidades){
            dao.Cadastro(cidades);
            return CreatedAtRoute("CidadeAtual", new {id=cidades.ID},cidades);
        }
    }
}