using MediatR;

namespace Qsti.Service.SincronizarDadosEquipamento.Domain.Commands.GlobalSearch.EnviarComandoQuen12
{
    public class EnviarComandoQuen12Request : IRequest<EnviarComandoQuen12Response>
    {
        public EnviarComandoQuen12Request(int idCliente, string identificacao)
        {
            IdCliente = idCliente;
            Identificacao = identificacao;
        }

        public int IdCliente { get; set; }
        public string Identificacao { get; set; }
    }
}
