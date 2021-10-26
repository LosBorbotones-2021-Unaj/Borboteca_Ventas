using Ventas_Domain.Commands;
using Ventas_Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.DTOs;
using Ventas_Domain.DTOs.CarroDtos;
using Ventas_Domain.Entities;

namespace Ventas_Application.Services
{
    public class CarroService : ICarroService
    {
        IGenericRepository Repository;
        ICarroQuery query;
        IQueryGeneric QueryGeneric;
        public CarroService(IGenericRepository _repository, ICarroQuery _query, IQueryGeneric xQueryGeneric)
        {
            Repository = _repository;
            query = _query;
            QueryGeneric = xQueryGeneric;
        }


        public void CreateCarro(int xUsuarioId)
        {
           

                if (!query.VerificarCarroActivo(xUsuarioId))
                {
                    var entity = new Carro
                    {
                        Valor = 0,
                        Activo = true,
                        Usuarioid = xUsuarioId

                    };

                    Repository.Add<Carro>(entity);                  
                                    
                }
            
        }
        public ResponseLibrosCarro GetLibrosDelCarro(int Usuarioid)
        {
            return query.GetLibrosDelCarroQuery(Usuarioid);
        }

        public void UpdateCarroActivo(int UsuarioId)
        {
            
            query.UpdateCarroActivoQuery(UsuarioId);
            CreateCarro(UsuarioId);
        }
    }
}
