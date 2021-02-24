using CalcularJuros.Api.Application.ServiceApp;
using CalcularJuros.Api.Domain.InterfaceService;
using CalcularJuros.Controllers;
using CalcularJuros.ServiceJuros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CalcularJuros.Api.TesteIntegracao.GitResponseTest
{
    public class GitControllerTest : ControllerBase
    {
        private readonly GitController _controller;
        private readonly ILogger<GitController> _logger;
        private readonly ICalculoJurosApp _serviceApp;
        private readonly ICalcularJurosService _calcularJurosService;
        private readonly IGitService _gitService;
        private readonly IApiGitService _gitApiService;


        public GitControllerTest()
        {
            _gitApiService = new ApiGitServiceTest();
            _gitService = new GitServiceTest();
            _serviceApp = new CalculoJurosApp(_calcularJurosService, _gitService);
            _logger = Mock.Of<ILogger<GitController>>();
            _controller = new GitController(_logger, _serviceApp);
        }

        [Fact]
        private async void CriaRetornoDeCalcularJurosTesteIntegral()
        {
            _logger.LogInformation("");
            var okResult = await _controller.RepositorioGit() as OkObjectResult;
            var retorno = okResult.Value;
            var valorEsperado =  new List<string>() { "api1", "api2" };
            Assert.Equal(valorEsperado, retorno);
        }
    }
}
