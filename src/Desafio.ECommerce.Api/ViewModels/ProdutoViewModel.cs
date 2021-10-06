using System;

namespace Desafio.ECommerce.Api.ViewModels
{
    public class ProdutoViewModel : BaseViewModel
    {
        public Guid PedidoId { get; set;  }
        public string Nome { get; set;  }
        public string Descricao { get; set;  }
        public decimal Valor { get; set;  }

    }
}