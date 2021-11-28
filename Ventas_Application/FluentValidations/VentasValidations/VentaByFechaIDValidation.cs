using FluentValidation;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Domain.DTOs.VentasDtos;

namespace Ventas_AccessData.Validations.VentasValidations
{
    public class VentaByFechaIDValidation : AbstractValidator<VentasValidate>
    {
       
        public VentaByFechaIDValidation()
        {
            RuleFor(x => x.Fecha).Must(FechaValidation).WithMessage("La fecha ingresada no tiene el formato correcto(yyyy-MM-dd)");
        }
        public bool FechaValidation(string Fecha)
        {
            
            try
            {
                if (Fecha != null)
                {
                    SimpleDateFormat formato = new SimpleDateFormat("yyyy-mm-dd");
                    DateTime Date = formato.Parse(Fecha);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
       
    }
    
}
