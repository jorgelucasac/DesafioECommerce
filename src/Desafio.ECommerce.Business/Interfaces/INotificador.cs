using System.Collections.Generic;
using Desafio.ECommerce.Business.Notificacoes;

namespace Desafio.ECommerce.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacoes();

        IList<Notificacao> ObterNotificacoes();
        void Notificar(Notificacao notificacao);
        void Notificar(string chave, string mensagem);
    }
}