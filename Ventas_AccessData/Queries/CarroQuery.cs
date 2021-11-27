using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Ventas_Domain.DTOs;
using Ventas_Domain.DTOs.CarroDtos;
using Ventas_Domain.DTOs.CarroLibroDtos;
using Ventas_Domain.DTOs.VentasDtos;
using Ventas_Domain.Entities;
using Ventas_Domain.Queries;

namespace Ventas_AccessData.Queries
{
    public class CarroQuery : ICarroQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sklKataCompiler;
        private readonly VentasContext context;
        public CarroQuery(IDbConnection xconnection, Compiler xsklKataCompiler, VentasContext dbContext)
        {
            connection = xconnection;
            sklKataCompiler = xsklKataCompiler;
            context = dbContext;
        }



        public ResponseLibrosCarro GetLibrosDelCarroQuery(int Usuarioid)
        {
            var db = new QueryFactory(connection, sklKataCompiler);

            var Carro = db.Query("Carro")
                        .Select("Id", "Valor", "Activo", "UsuarioId")
                        .Where("UsuarioId", "=", Usuarioid)
                        .Where("Activo", "=", true).FirstOrDefault<Carro>();
            if (Carro != null)
            {
                var ListaLibros = context.CarroLibro.Where(w => w.Carroid == Carro.Id).Select(c => c.Libroid).ToList();


                return new ResponseLibrosCarro
                {
                    LibrosIds = ListaLibros,
                    ValorTotalCarro = Carro.Valor

                };
            }
            else return new ResponseLibrosCarro { };
                
            
        }

        public bool VerificarCarroActivo(int UsuarioId)
        {

           
            var Carro = context.Carro.Where(w => w.Activo == true).Where(x => x.Usuarioid == UsuarioId).Select(c => c).FirstOrDefault();
            

            if (Carro != null)
            {                
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateCarroActivoQuery(int usuarioId)
        {
            Carro Carro = context.Carro.Where(c => c.Usuarioid == usuarioId).Where(c => c.Activo == true).FirstOrDefault();
            Carro.Activo = false;
            context.Update(Carro);
            context.SaveChanges();
        }

        public int GetCarroByUsuarioId(int UsuarioId)
        {
            int CarroId = context.Carro.Where(c => c.Usuarioid == UsuarioId).Where(c => c.Activo == true).Select(C => C.Id).FirstOrDefault();
            return CarroId;
        }

        public ResponseLibrosCarro GetMisLibrosQuery(int Usuarioid)
        {

            var MisLibros = (from C in context.Carro
                             join CL in context.CarroLibro on C.Id equals CL.Carroid
                             into union_C_CL
                             from C_CL in union_C_CL.DefaultIfEmpty()
                             where C.Usuarioid == Usuarioid && C.Activo == false
                             group C_CL by C_CL.Libroid into Ids
                             select Ids.Key).ToList();


            return new ResponseLibrosCarro { LibrosIds = MisLibros };
        }

    }
}