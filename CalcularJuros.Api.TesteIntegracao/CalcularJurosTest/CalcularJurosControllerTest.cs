using CalcularJuros.Api.Application.ServiceApp;
using CalcularJuros.Api.Application.ViewModels;
using CalcularJuros.Api.Core.DomainObjects;
using CalcularJuros.Api.Domain.InterfaceService;
using CalcularJuros.Api.Domain.Service;
using CalcularJuros.Controllers;
using CalcularJuros.ServiceJuros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalcularJuros.Api.TesteIntegracao
{
    public class CalcularJurosControllerTest : ControllerBase
    {
        private readonly CalcularJurosController _controller;
        private readonly ICalculoJurosApp _serviceApp;
        private readonly ICalcularJurosService _calcularJurosService;
        private readonly IJurosService _jurosService;
        private readonly IGitService _gitService;
        private ILogger<CalcularJurosController> _logger;

        private CalculoJurosViewModel calculo;

        public CalcularJurosControllerTest()
        {

            // instanciar variavel calculo
            InstanciarCalculo();
            _calcularJurosService = new CalcularJurosService();
            _logger = Mock.Of<ILogger<CalcularJurosController>>();
            _serviceApp = new CalculoJurosApp(_calcularJurosService, _gitService);
            _jurosService = new JurosServiceTest();
            _controller = new CalcularJurosController(_jurosService, _logger, _serviceApp);
        }

        [Fact]
        private async void CriaRetornoDeCalcularJurosTesteIntegral()
        {
            var valorEsperado = "105,10";
            _logger.LogInformation("");
            var okResult = await _controller.CalcularJurosComposto(calculo) as OkObjectResult;
            var retorno = okResult.Value;

            Assert.Equal(valorEsperado, retorno);
        }

        [Fact]
        private void CriaDomainExceptionEmCalcularJurosTesteIntegral()
        {
            _logger.LogInformation("");
            var t = new DomainException("Valor final não pode ser igual a zero");
            Assert.ThrowsAsync<DomainException>(async () => await _controller.CalcularJurosComposto(calculo));
        }

        private void InstanciarCalculo()
        {
            calculo = new CalculoJurosViewModel();
            calculo.Meses = 5;
            calculo.ValorInicial = 100;

        }
    }
}
