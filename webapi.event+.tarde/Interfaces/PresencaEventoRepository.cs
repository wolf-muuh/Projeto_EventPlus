using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Cadastrar(PresencaEvento presencaEvento)
        {
            _eventContext.PresencaEventos.Add(presencaEvento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            PresencaEvento presencaEvento = _eventContext.PresencaEventos.FirstOrDefault(x => x.IdPresencaEvento == id)!;
            _eventContext.PresencaEventos.Remove(presencaEvento);
            _eventContext.SaveChanges();
        }

        public List<PresencaEvento> ListarPresencas(Guid id)
        {
            List<PresencaEvento> presencaEventos = _eventContext.PresencaEventos.Where(x => x.IdUsuario == id).ToList();

            return presencaEventos;
        }
    }
}
