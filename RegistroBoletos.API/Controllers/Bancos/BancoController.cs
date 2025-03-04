using Microsoft.AspNetCore.Mvc;
using RegistroBoletos.API.Bases;
using RegistroBoletos.Application.Bancos;
using RegistroBoletos.Application.Bancos.Dtos;

namespace RegistroBoletos.API.Controllers.Bancos
{
    [ApiController]
    [Route("api/Banco")]
    public class BancoController : ControllerBase
    {
        private readonly IAplicBanco _aplic;

        public BancoController(IAplicBanco aplic)
        {
            _aplic = aplic;
        }

        [HttpPost("InserirNovoBanco")]
        public IActionResult InserirNovoBanco([FromBody] InserirBancoDto dto)
        {
            try
            {
                _aplic.InserirNovoBanco(dto);
                return new ResponseHttps().RetSucesso();
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetErro(ex.Message);
            }
        }

        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos()
        {
            try
            {
                var ret = _aplic.ListarTodos();
                return new ResponseHttps().RetSucesso(content: ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetErro(ex.Message);
            }
        }

        [HttpGet("RecuperarBanco/{codigoBanco}")]
        public IActionResult RecuperarBanco([FromRoute] string codigoBanco)
        {
            try
            {
                var ret = _aplic.RecuperarBanco(codigoBanco);
                return new ResponseHttps().RetSucesso(content: ret);
            }
            catch (Exception ex)
            {
                return new ResponseHttps().RetErro(ex.Message);
            }
        }
    }
}
