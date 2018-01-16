using System.Collections.Generic;

namespace WebServicesCidades.Models {
    public class Cidades {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }

        public List<Cidades> Listar () {
            return new List<Cidades> () {
                new Cidades { ID = 10, Nome = "Leme", Estado = "SP", Habitantes = 312 },
                new Cidades { ID = 32, Nome = "Curitiba", Estado = "PR", Habitantes = 565 },
                new Cidades { ID = 65, Nome = "Florianopolis", Estado = "SC", Habitantes = 45 },
                new Cidades { ID = 75, Nome = "Rio de Janeiro", Estado = "RJ", Habitantes = 98876 }
            };
        }
    }
}