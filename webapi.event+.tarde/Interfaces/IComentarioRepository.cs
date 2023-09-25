using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IComentarioRepository
    {
        void Comentario(ComentarioEvento com);

        List<ComentarioEvento> ListarComentariosUsuario(Guid id);

        void Deletar(Guid id);
    }
}
