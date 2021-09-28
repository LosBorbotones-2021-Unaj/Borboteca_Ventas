using FluentValidation;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs.VentasDtos;

namespace Ventas_AccessData.Validations.VentasValidations
{
    public class CreateVentaValidation : AbstractValidator<RequestVenta>
    {
        public CreateVentaValidation()
        {
            RuleFor(x => x.Fecha).NotEmpty().NotNull().WithMessage("El campo Fecha no puede estar vacio. - ");
            RuleFor(x => x.Fecha).Must(FechaValidation).WithMessage("El formato de la fecha ingresada no es correcto. Debe ser del tipo: yyyy-MM-dd. - ");

            RuleFor(x => x.Comprobante).NotEmpty().NotNull().WithMessage("El campo Comprobante no puede estar vacio. - ");
            RuleFor(x => x.Comprobante).MaximumLength(500).WithMessage("El campo Comprobante no puede tener mas de 500 caracteres. - ");
            
            RuleFor(x => x.estado).NotEmpty().NotNull().WithMessage("El campo estado no puede estar vacio. - ");

            RuleFor(x => x.CarroId).GreaterThan(0).WithMessage("El campo CarroId no puede ser menor a 0. - ");
            RuleFor(x => x.CarroId).NotEmpty().NotNull().WithMessage("El campo CarroId no puede estar vacio. ");
            
        }
       public bool FechaValidation(string fecha)
        {
            try
            {
                SimpleDateFormat formato = new SimpleDateFormat("yyyy-mm-dd");
                DateTime Date = formato.Parse(fecha);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
       
    }
            
       
}
