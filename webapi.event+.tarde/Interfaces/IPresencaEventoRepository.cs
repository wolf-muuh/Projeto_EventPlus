using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IPresencaEventoRepository
    {
        List<PresencaEvento> ListarPresencas(Guid id);

        void Cadastrar(PresencaEvento presencaEvento);

        void Deletar(Guid id);
    }
}
