using System;
using System.Collections.Generic;

namespace Desafio.ECommerce.Api.ViewModels
{
    public class PedidoViewModel : BaseViewModel
    {
        public Guid EquipeId { get; set; }
        public int NumeroIdentificacao { get; set; }
        public DateTime? DataEntrega { get; set; }

        public EquipeViewModel Equipe { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public List<ProdutoViewModel> Produtos { get; set; }
    }
}