using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _eventContext;

        public TipoEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento tipoBuscado = _eventContext.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;

            if (tipoEvento != null)
            {
                tipoBuscado.Titulo = tipoEvento.Titulo;
            }

            _eventContext.TipoEvento.Update(tipoBuscado!);

            _eventContext.SaveChanges();
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            List<TipoEvento> tipoEventos = _eventContext.TipoEvento.ToList();

            TipoEvento tipoEvento = _eventContext.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;

            return tipoEvento;
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                _eventContext.TipoEvento.Add(tipoEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            TipoEvento tipoEventos = _eventContext.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;

            _eventContext.TipoEvento.Remove(tipoEventos);

            _eventContext.SaveChanges();
        }

        public List<TipoEvento> Listar()
        {
            try
            {
                return _eventContext.TipoEvento.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }   
}
