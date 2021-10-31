using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.Entities;

namespace Ventas_Application.FluentValidations.CarroValidations
{
    public class CreateCarroValidate : AbstractValidator<Carro>
    {
        public CreateCarroValidate()
        {
            RuleFor(Carro => Carro.Usuarioid).NotEmpty().NotNull().WithMessage("El campo UsuarioId no puede ser nulo.   ");
        
        }

     
    }
}
