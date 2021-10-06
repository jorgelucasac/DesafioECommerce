using System.Linq;
using System.Threading.Tasks;
using Desafio.ECommerce.Business.Interfaces;
using Desafio.ECommerce.Business.Models;
using Desafio.ECommerce.Business.Paginacao;
using Desafio.ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.ECommerce.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context) { }

        public async Task<PagedResult<Pedido>> ObterPedidos(int pagina, int quantidade)
        {
            var qtdRegistrosPular = quantidade * (pagina - 1);
            var query =  await Context.Pedidos
                .Include(e => e.Equipe)
                .Include(p => p.Produtos)
                .Include(e => e.Endereco)
                .Skip(qtdRegistrosPular).Take(quantidade).ToListAsync();

            return new PagedResult<Pedido>()
            {
                List = query,
                TotalResults = query.Count,
                PageIndex = pagina,
                PageSize = quantidade,
            };
        }
    }
}