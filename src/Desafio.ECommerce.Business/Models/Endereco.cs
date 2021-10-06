using System;

namespace Desafio.ECommerce.Business.Models
{
    public class Endereco : Entity
    {
        public Guid PedidoId { get; set;  }

        public string Logradouro { get; set;  }
        public string Numero { get; set;  }
        public string Complemento { get; set;  }
        public string Cep { get; set;  }
        public string Bairro { get; set;  }
        public string Cidade { get; set;  }
        public string Estado { get; set;  }

        /* EF Relation */
        public Pedido Pedido { get; set;  }
    }
}