using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Instituicao instituto)
        {
            Instituicao instituicaoAntiga = _eventContext.Instituicao.FirstOrDefault(x => x.IdInstituicao == id)!;

            if (instituicaoAntiga != null)
            {
                instituicaoAntiga.NomeFantasia = instituto.NomeFantasia;
                instituicaoAntiga.CNPJ = instituto.CNPJ;
                instituicaoAntiga.Endereco = instituto.Endereco;
            }

            _eventContext.Instituicao.Update(instituicaoAntiga);
            _eventContext.SaveChanges();
        }

        public Instituicao BuscarPorId(Guid id)
        {
            List<Instituicao> instituicaos = _eventContext.Instituicao.ToList();
            Instituicao instituto = instituicaos.FirstOrDefault(x => x.IdInstituicao == id)!;
            return instituto!;
        }

        public void Cadastrar(Instituicao instituto)
        {
            _eventContext.Instituicao.Add(instituto);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Instituicao instituicao = _eventContext.Instituicao.FirstOrDefault(x => x.IdInstituicao == id)!;
            _eventContext.Instituicao.Remove(instituicao);
            _eventContext.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            List<Instituicao> instituicoes = _eventContext.Instituicao.ToList();

            return instituicoes;
        }
    }
}
