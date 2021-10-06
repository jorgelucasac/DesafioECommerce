using System;
using System.Collections.Generic;

namespace Desafio.ECommerce.Business.Models
{
    public class Pedido : Entity
    {
        public Guid EquipeId { get; set; }
        public int NumeroIdentificacao { get; set; }
        public DateTime? DataEntrega { get; set; }

        /* EF Relation */
        public Equipe Equipe { get; set;  }
        public Endereco Endereco { get; set;  }
        public List<Produto> Produtos { get; set;  }
    }
}