using System;

namespace Desafio.ECommerce.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            DataCadastro = DateTime.Now;
            Id = Guid.NewGuid();
            Ativar();

        }

        public Guid Id { get; }
        public DateTime DataCadastro { get; }
        public DateTime? DataExclusao { get; set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Desativar()
        {
            Ativo = false;
        }
        public void Exluir()
        {
            Excluido = true;
            DataExclusao = DateTime.Now;
        }


    }
}