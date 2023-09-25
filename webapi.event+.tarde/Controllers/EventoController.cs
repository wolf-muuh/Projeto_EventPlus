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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _EventoRepository { get; set; }

        public EventoController()
        {
            _EventoRepository = new EventoRepository();
        }

        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _EventoRepository.Cadastrar(evento);

                return StatusCode(201);
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
                List<Evento> Eventos = _EventoRepository.Listar();

                return Ok(Eventos);
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
                Evento evento = _EventoRepository.BuscarPorId(id);
                return Ok(evento);
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
                _EventoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPut]
        public IActionResult Put(Guid id, Evento evento)
        {
            try
            {
                _EventoRepository.Atualizar(id, evento);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
