using CalcularJuros.Api.Application.ServiceApp;
using CalcularJuros.ServiceJuros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcularJuros.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GitController : ControllerBase
    {

        private readonly ILogger<GitController> _logger;
        private readonly ICalculoJurosApp _calculoJurosApp;

        public GitController(
            ILogger<GitController> logger,
            ICalculoJurosApp calculoJurosApp)
        {
            _logger = logger;
            _calculoJurosApp = calculoJurosApp;
        }
        [HttpGet]
        [Route("showmethecode")]
        public async Task<IActionResult> RepositorioGit()
        {
            _logger.LogInformation("Buscando o Repositorio Git");
            //meu usuario
            IEnumerable<string> repo = await _calculoJurosApp.GetRepositorioGit("lorranmoncada");
            _logger.LogInformation("Repositorio retornado");

            return Ok(repo);

        }
    }
}
