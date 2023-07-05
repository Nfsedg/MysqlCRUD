using Diesño.Context;
using Diesño.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diesño.Services
{
    internal class EmpleadoServices
    {
        public void Add(Empleados request)
        {
			try
			{
				using(var _context = new AppDBCContext())
				{
                    Empleados empleado = new Empleados()
                    {
						Nombre = request.Nombre,
						Correo = request.Correo,
						Apellido = request.Apellido,
						FechaRegistro = DateTime.Now

                    };
					_context.Empleados.Add(empleado);
					_context.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw new Exception("Sucedió un error " + ex.Message);
			}
        }
		public Empleados Red (int id)
		{
			try
			{
				Empleados empleado = new();
				using(var _context = new AppDBCContext())
				{
					empleado = _context.Empleados.Find(id);
				}
				return empleado;
			} catch(Exception ex)
            {
				throw new Exception(ex.Message);
            }
		}

		public void Update (Empleados request)
        {
            try
            {
				using(var _context = new AppDBCContext())
                {
					Empleados update = _context.Empleados.Find(request.PkEmpleado);
					update = new Empleados()
					{
						Nombre = request.Nombre,
						Apellido = request.Apellido,
						Correo = request.Correo,
						FechaRegistro = DateTime.Now
					};
					_context.Entry(update).State = EntityState.Modified;
					//_context.Update(update);
                }
            } catch(Exception ex)
            {
				throw new Exception (ex.Message);
            }
        }
    }
}
