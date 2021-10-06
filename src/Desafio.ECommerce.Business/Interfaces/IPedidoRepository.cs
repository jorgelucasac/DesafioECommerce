using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.ECommerce.Business.Models;
using Desafio.ECommerce.Business.Paginacao;

namespace Desafio.ECommerce.Business.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<PagedResult<Pedido>> ObterPedidos(int pagina, int quantidade);
    }
}