using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.Core.Validation
{
    public abstract class Validation
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool EhValido();      
    }
}
