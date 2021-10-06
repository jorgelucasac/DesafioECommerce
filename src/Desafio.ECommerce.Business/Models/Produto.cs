using System;

namespace Desafio.ECommerce.Business.Models
{
    public class Produto : Entity
    {
        public Guid PedidoId { get; set;  }
        public string Nome { get; set;  }
        public string Descricao { get; set;  }
        public decimal Valor { get; set;  }

        /* EF Relation */
        public Pedido Pedido { get; set;  }
    }
}