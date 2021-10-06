using System.Collections.Generic;

namespace Desafio.ECommerce.Business.Models
{
    public class Equipe : Entity
    {
        public string Nome { get; set;  }
        public string Descricao { get; set;  }
        public string PlacaVeiculo { get; set;  }


        /* EF Relation */
        public List<Pedido> Pedidos { get; set;  }
    }
}