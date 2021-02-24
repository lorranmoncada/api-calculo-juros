using CalcularJuros.Api.Core.DomainObjects;
using CalcularJuros.Api.Core.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.Domain.Model
{
    public class CalculoJuros : Validation
    {
        public int Meses { get; private set; }
        public decimal ValorInicial { get; private set; }

        public CalculoJuros(int meses, decimal valorInicial)
        {
            Meses = meses;
            ValorInicial = valorInicial;
            EhValido();
        }

        public override bool EhValido()
        {
            ValidationResult = new CalcularJurosValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public string CalcularJurosComposto(decimal juros)
        {
            var VlInicial = Convert.ToDouble(ValorInicial);
            var TxJuros = Convert.ToDouble(juros);
            var Periodo = Convert.ToDouble(Meses);
            var ValorFinal = VlInicial * Math.Pow(1 + TxJuros, Periodo);

            if (ValorFinal == 0)
            {
                throw new DomainException("Valor final não pode ser igual a zero");
            }

            return string.Format("{0:0.00}", ValorFinal);
        }

        private class CalcularJurosValidation : AbstractValidator<CalculoJuros>
        {

            public CalcularJurosValidation()
            {
                RuleFor(c => c.Meses).GreaterThan(0).WithMessage("O mês deve ser maio que zero");
                RuleFor(c => c.ValorInicial).GreaterThan(0).WithMessage("O Valor inicial deve ser maio que zero");
            }
        }
    }
}
