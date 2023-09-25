using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly EventContext _eventContext;

        public ComentarioRepository()
        {
            _eventContext = new EventContext();
        }

        public void Comentario(ComentarioEvento com)
        {
            _eventContext.ComentarioEvento.Add(com);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            ComentarioEvento comDelete = _eventContext.ComentarioEvento.FirstOrDefault(x => x.IdComentarioEvento == id)!;
            _eventContext.ComentarioEvento.Remove(comDelete);
            _eventContext.SaveChanges();
        }

        public List<ComentarioEvento> ListarComentariosUsuario(Guid id)
        {
            List<ComentarioEvento> comentarios = _eventContext.ComentarioEvento.Where(x => x.IdUsuario == id).ToList();

            return comentarios;
        }
    }
}
