using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoAntigo = _eventContext.Evento.FirstOrDefault(x => x.IdEvento == id)!;

            if (eventoAntigo != null)
            {
                eventoAntigo.IdInstituicao = evento.IdInstituicao;
                eventoAntigo.IdTipoEvento = evento.IdTipoEvento;
                eventoAntigo.DataEvento = evento.DataEvento;
                eventoAntigo.Descricao = evento.Descricao;
                eventoAntigo.NomeEvento = evento.NomeEvento;
            }

            _eventContext.Evento.Update(eventoAntigo!);
            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            List<Evento> eventos = _eventContext.Evento.ToList();
            Evento evento = eventos.FirstOrDefault(x => x.IdEvento == id)!;
            return evento!;
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Evento evento = _eventContext.Evento.FirstOrDefault(x => x.IdEvento == id)!;
            _eventContext.Evento.Remove(evento);
            _eventContext.SaveChanges();
        }

        public List<Evento> Listar()
        {
            try
            {
                return _eventContext.Evento.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
