using CalcularJuros.Api.Application.ServiceApp;
using CalcularJuros.Api.Application.ViewModels;
using CalcularJuros.Api.Domain.InterfaceService;
using CalcularJuros.Api.Domain.Model;
using CalcularJuros.ServiceJuros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalcularJuros.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CalcularJurosController : ControllerBase
    {

        private readonly IJurosService _jurosService;
        private readonly ILogger<CalcularJurosController> _logger;
        private readonly ICalculoJurosApp _calculoJurosApp;

        public CalcularJurosController(IJurosService jurosService,
            ILogger<CalcularJurosController> logger,
            ICalculoJurosApp calculoJurosApp)
        {
           
            _jurosService = jurosService;
            _logger = logger;
            _calculoJurosApp = calculoJurosApp;
        }

        /// <summary>
        /// Retorna o calculo de juros composto
        /// </summary>
        /// <response code="200">Calculo executado e valor retornado</response>
        /// <response code="400">Valores inválidos</response>
        /// <response code="500">Não foi possível executar o calculo neste momento</response>
        [HttpGet]
        [Route("calculajuros")]
        public async Task<IActionResult> CalcularJurosComposto([FromQuery] CalculoJurosViewModel calcular)
        {
            _logger.LogInformation("Buscando o valor de taxa de Juros na api de Juros");
            var juros = await _jurosService.GetJuros();
            _logger.LogInformation("Valor de taxa de Juros retornado");
            _logger.LogInformation("Chamando metodo de calculo de juros composto");
            return Ok(_calculoJurosApp.GetJurosComposto(calcular.Meses, calcular.ValorInicial, juros));

        }
    }
}
