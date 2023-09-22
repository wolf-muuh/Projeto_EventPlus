using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario tipoBuscado = _eventContext.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;

            if (tipoUsuario != null)
            {
                tipoBuscado.Titulo = tipoUsuario.Titulo;
            }

            _eventContext.TipoUsuario.Update(tipoBuscado!);

            _eventContext.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            List<TipoUsuario> tipoUsuarios = _eventContext.TipoUsuario.ToList();

            TipoUsuario tipoUsuario = _eventContext.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;

            return tipoUsuario;
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipoUsuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public void Deletar(Guid id)
        {
            TipoUsuario tipoUsuario = _eventContext.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;

            _eventContext.TipoUsuario.Remove(tipoUsuario);

            _eventContext.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return _eventContext.TipoUsuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
