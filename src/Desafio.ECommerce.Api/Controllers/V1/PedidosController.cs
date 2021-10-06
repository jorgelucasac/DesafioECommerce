using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Desafio.ECommerce.Api.Filters;
using Desafio.ECommerce.Api.ViewModels;
using Desafio.ECommerce.Business.Interfaces;
using Desafio.ECommerce.Business.Paginacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.ECommerce.Api.Controllers.V1
{

    [ApiVersion("1.0")]
    public class PedidosController : BaseApiController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        public PedidosController(INotificador notificador, IMapper mapper, IPedidoRepository pedidoRepository) : base(notificador)
        {
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
        }


        /// <summary>
        /// Obtenha os pedidos paginados
        /// </summary>
        /// 
        /// <returns>lista de <see cref="PedidoViewModel"/></returns>
        /// <param name="pagina">Pagina desejada</param>
        /// <param name="quantidade">Quantidade de itens por página</param>
        /// <response code="200">Retorna os pedidos encontrados</response>
        /// <response code="204">Caso não exista registros</response>
        /// <response code="401">Caso o token não seja informado ou esteja inválido</response>
        /// <response code="500">Em caso de erro</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<PedidoViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ResponseInternalServerError]
        [ResponseUnauthorized]
        public async Task<ActionResult<PagedResult<PedidoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina, [FromQuery, Range(1, 50)] int quantidade)
        {

            var pedidos = await ObterPedidos(pagina, quantidade);
            return ResponseGetPaginado(pedidos);
        }

        private async Task<PagedResult<PedidoViewModel>> ObterPedidos(int pagina, int quantidade)
        {
            var listaPedidos = await _pedidoRepository.ObterPedidos(pagina, quantidade);
            var retorno = new PagedResult<PedidoViewModel>
            {
                PageIndex = listaPedidos.PageIndex,
                PageSize = listaPedidos.PageSize,
                TotalResults = listaPedidos.TotalResults,
                List = _mapper.Map<List<PedidoViewModel>>(listaPedidos.List)
            };
            return retorno;
        }
    }
}