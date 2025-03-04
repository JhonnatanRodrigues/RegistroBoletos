using Microsoft.AspNetCore.Mvc;
using RegistroBoletos.API.Bases;
using RegistroBoletos.Application.Boletos;
using RegistroBoletos.Application.Boletos.Dtos;

namespace RegistroBoletos.API.Controllers.Boletos
{
    [Controller]
    [Route("api/Boleto")]
    public class BoletoController : ControllerBase
    {
        private readonly IAplicBoleto _aplicBoleto;

        public BoletoController(IAplicBoleto aplicBoleto)
        {
            _aplicBoleto = aplicBoleto;
        }

        [HttpPost("InserirNovoBoleto")]
        public IActionResult InserirNovoBoleto([FromBody] BoletoDto dto)
        {
            try
            {
                _aplicBoleto.InserirNovoBoleto(dto);

                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetErro(ex.Message);
            }
        }

        [HttpGet("RecuperarBoleto/{id}")]
        public IActionResult RecuperarBoleto([FromRoute] Guid id)
        {
            try
            {
                var ret = _aplicBoleto.RecuperarBoleto(id);

                return new ResponseHttps().RetSucesso(content: ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetErro(ex.Message);
            }
        }

        [HttpGet("ListarTodosBoletos")]
        public IActionResult ListarTodosBoletos()
        {
            try
            {
                var ret = _aplicBoleto.ListarTodosBoletos();

                return new ResponseHttps().RetSucesso(content: ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetErro(ex.Message);
            }
        }
    }
}
