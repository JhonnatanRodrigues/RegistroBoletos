using FrozenForge.Apis;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RegistroBoletos.API.Bases
{
    public class ResponseHttps : ApiResponse
    {
        public bool Success { get; private set; }

        public IActionResult RetSucesso(object? content = null, string? msg = null)
        {
            StatusCode = HttpStatusCode.OK;
            Success = true;
            Body = content;
            ReasonPhrase = msg;
            return new Controller_Base().Ok(this);
        }
        public IActionResult RetErro(string? msg)
        {
            StatusCode = HttpStatusCode.BadRequest;
            ReasonPhrase = msg;
            Success = false;

            return new Controller_Base().BadRequest(this);
        }
    }
}
