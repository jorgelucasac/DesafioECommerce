using System;

namespace Desafio.ECommerce.Business.Notificacoes
{
    public class Notificacao
    {
        public Guid Id { get; }
        public string Chave { get; }
        public string Valor { get; }

        public Notificacao(string chave, string valor)
        {
            Id = Guid.NewGuid();
            Chave = chave;
            Valor = valor;
        }
    }
}