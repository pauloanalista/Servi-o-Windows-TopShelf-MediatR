using MediatR;
using Qsti.Service.SincronizarDadosEquipamento.Domain.Commands.GlobalSearch.EnviarComandoQuen12;
using System.Threading;

namespace Qsti.Service.SincronizarDadosEquipamento
{
    public class ServiceSincronizarDadosEquipamento
    {
        private IMediator _mediator;

        public ServiceSincronizarDadosEquipamento(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool Start()
        {
            var request = new EnviarComandoQuen12Request(1, "aa");
            _mediator.Send(request, CancellationToken.None);



            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            return true;
        }

        public bool Stop()
        {
            return true;
        }
    }
}
