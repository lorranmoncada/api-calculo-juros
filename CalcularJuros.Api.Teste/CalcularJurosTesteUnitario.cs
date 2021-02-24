using CalcularJuros.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalcularJuros.Api.Teste
{
    public class CalcularJurosTesteUnitario
    {
        [Fact]
        public void VerificaMesDaClasseCalculoJuros()
        {
            var calculo = new CalculoJuros(0, 0.1M);
            Assert.False(calculo.EhValido());
        }

        [Fact]
        public void VerificaMensagemMesDaClasseCalculoJuros()
        {
            var message = new CalculoJuros(0, 0.1M);
            Assert.Equal("O mês deve ser maio que zero", message.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact]
        public void VerificaMensagemValorInicialDaClasseCalculoJuros()
        {
            var message = new CalculoJuros(5, 0);
            Assert.Equal("O Valor inicial deve ser maio que zero", message.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact]
        public void VerificaValorInicialDaClasseCalculoJuros()
        {
            var calculo = new CalculoJuros(5, 0);
            Assert.False(calculo.EhValido());
        }
    }
}
