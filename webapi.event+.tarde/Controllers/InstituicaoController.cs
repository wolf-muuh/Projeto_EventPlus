using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Instituicao> instituicoes = _instituicaoRepository.Listar();

                return Ok(instituicoes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _instituicaoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Instituicao instituicao = _instituicaoRepository.BuscarPorId(id);

                return Ok(instituicao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicao);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
