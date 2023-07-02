using Basedadetos.Context;
using Basedadetos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basedadetos.Services
{
    public class EmpleadoServices
    {

        #region AGREGAR
        public void Add(Empleado  request)
        {
			try
			{
				

				using(var _context= new AplicationDbContext()) //abrir y cerrar automaticamente la cadena
				{
                    Empleado empleado = new Empleado()
                    {
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                        FechaRegistro = DateTime.Now,
                        Correo = request.Correo,
                        
                    };
                    _context.Empleados.Add(empleado);
                    _context.SaveChanges();
                }

			}
			catch (Exception ex)
			{

				throw new Exception("Sucedio un error"+ex.Message);
			}
        }

        #endregion


        #region LEER
        public Empleado Read(int ID)
        {
            try
            {
                Empleado empleado = new Empleado();

                using (var _context = new AplicationDbContext())
                {
                    empleado = _context.Empleados.Find(ID);
                    return empleado;

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        #endregion

        #region BORRAR
        public Empleado Delete(int ID)
        {
            try
            {
                Empleado empleado = new Empleado();

                using (var _context = new AplicationDbContext())
                {
                    empleado = _context.Empleados.Find(ID);
                    _context.Empleados.Remove(empleado);
                    _context.SaveChanges();
                    return empleado;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        #endregion


        #region EDITAR
        public Empleado Update(int id)
        {
            try
            {
                using (var _context = new AplicationDbContext())
                {
                    Empleado empleado = _context.Empleados.Find(id);

                    if (empleado != null)
                    {
                        return empleado;
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al buscar el empleado en la base de datos: " + ex.Message);
            }
        }

        #endregion

        #region RESET
        public void ResetDatabase()
        {
            try
            {
                using (var _context = new AplicationDbContext())
                {
                    _context.Database.ExecuteSqlRaw("TRUNCATE TABLE Empleados");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al resetear la base de datos: " + ex.Message);
            }
        }
        #endregion


    }
}
