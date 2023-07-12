using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BL
{
    public class Restaurante
    {
        public static ML.Result GetAll(ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RestauranteEjercicioContext context = new DL.RestauranteEjercicioContext())
                {
                    var queryEF = context.Restaurantes.FromSqlRaw($"RestauranteGetAll '{restaurante.Nombre}'").ToList();
                    result.Objects = new List<object>();
                    if (queryEF != null)
                    {
                        foreach (var obj in queryEF)
                        {
                            ML.Restaurante restaurante1 = new ML.Restaurante();
                            restaurante1.IdRestaurante = obj.IdRestaurante;
                            restaurante1.Nombre = obj.Nombre;
                            restaurante1.FechaInauguracion = obj.FechaInauguracion;
                            restaurante1.CantidadEmpleados = obj.CantidadEmpleados;
                            restaurante1.CapacidadClientes = obj.CapacidadClientes;
                            restaurante1.Calificacion = obj.Calificacion;
                            result.Objects.Add(restaurante1);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch
            {
                result.Correct = false;

            }
            return result;
        }
        public static ML.Result GetById(int IdRestaurante)
        {
            ML.Result result = new ML.Result();
            try
            {


                using (DL.RestauranteEjercicioContext context = new DL.RestauranteEjercicioContext())
                {
                    var query = context.Restaurantes.FromSqlRaw($"RestauranteGetById {IdRestaurante}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                            ML.Restaurante restaurante1 = new ML.Restaurante();
                            restaurante1.IdRestaurante = query.IdRestaurante;
                            restaurante1.Nombre = query.Nombre;
                            restaurante1.CantidadEmpleados = query.CantidadEmpleados;
                            restaurante1.CapacidadClientes = query.CapacidadClientes;
                            restaurante1.Calificacion = query.Calificacion;
                            result.Object = restaurante1;
                        
                        result.Correct = true;
                    }
                }
            }
            catch
            {
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Add(ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RestauranteEjercicioContext context = new DL.RestauranteEjercicioContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"RestauranteAdd  '{restaurante.Nombre}', {restaurante.CantidadEmpleados}, {restaurante.CapacidadClientes}, '{restaurante.FechaInauguracion}', {restaurante.Calificacion}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch
            {
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Update(ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RestauranteEjercicioContext context = new DL.RestauranteEjercicioContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"RestauranteAdd  '{restaurante.IdRestaurante},'{restaurante.Nombre}', {restaurante.CantidadEmpleados}, {restaurante.CapacidadClientes}, '{restaurante.FechaInauguracion}', {restaurante.Calificacion}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch
            {
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Delete(int IdRestaurante)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RestauranteEjercicioContext context = new DL.RestauranteEjercicioContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"RestauranteDelete  {IdRestaurante}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch
            {
                result.Correct = false;
            }
            return result;
        }

    }
}