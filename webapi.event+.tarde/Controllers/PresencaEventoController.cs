using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class PresencaEventoController : ControllerBase
    {
        private IPresencaEventoRepository _presencaEventoRepository;

        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }

        [HttpPost]
        public IActionResult Post(PresencaEvento presenca)
        {
            try
            {
                _presencaEventoRepository.Cadastrar(presenca);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<PresencaEvento> p = _presencaEventoRepository.ListarPresencas(id);
                return Ok(p);
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
                _presencaEventoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
