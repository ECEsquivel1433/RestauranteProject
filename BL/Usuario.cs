using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {

        public static ML.Result GetByUsername(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RestauranteEjercicioContext context = new DL.RestauranteEjercicioContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetByUsername '{usuario.Username}'").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuario usuario1 = new ML.Usuario();
                        usuario1.IdUsuario = query.IdUsuario;
                        usuario1.Nombre = query.Nombre;
                        usuario1.Username = query.Username;
                        usuario1.Contraseña = query.Contraseña;
                        result.Object = usuario1;

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

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            using (DL.RestauranteEjercicioContext context = new DL.RestauranteEjercicioContext())
            {
                var query = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}', '{usuario.Username}', @Contraseña", new SqlParameter("@Contraseña", usuario.Contraseña));
                if(query >= 1)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                }
                return result;
            }
        }
    }
}
