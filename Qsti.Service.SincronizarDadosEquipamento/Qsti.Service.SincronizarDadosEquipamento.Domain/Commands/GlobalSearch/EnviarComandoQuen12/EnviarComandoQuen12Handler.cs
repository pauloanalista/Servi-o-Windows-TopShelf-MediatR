using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qsti.Service.SincronizarDadosEquipamento.Domain.Commands.GlobalSearch.EnviarComandoQuen12
{
    public class EnviarComandoQuen12Handler : IRequestHandler<EnviarComandoQuen12Request, EnviarComandoQuen12Response>
    {
        private readonly IMediator _mediator;

        public EnviarComandoQuen12Handler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<EnviarComandoQuen12Response> Handle(EnviarComandoQuen12Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
