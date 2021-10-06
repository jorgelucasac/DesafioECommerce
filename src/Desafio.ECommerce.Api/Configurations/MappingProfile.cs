using AutoMapper;
using Desafio.ECommerce.Api.ViewModels;
using Desafio.ECommerce.Business.Models;

namespace Desafio.ECommerce.Api.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Equipe, EquipeViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Pedido, PedidoViewModel>();
        }
    }
}
