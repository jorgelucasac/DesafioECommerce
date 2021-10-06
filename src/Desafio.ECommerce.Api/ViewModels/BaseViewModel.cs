using System;

namespace Desafio.ECommerce.Api.ViewModels
{
    public abstract class BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; private set; }
    }
}