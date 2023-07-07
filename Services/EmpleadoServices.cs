using Diesño.Context;
using Diesño.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diesño.Services
{
    internal class EmpleadoServices
    {
        public void messageBox(string message)
        {
            string messageBoxText = message;
            string caption = "";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.None;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }
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

                throw new Exception("Sucedió un error " + ex.InnerException);
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
                    update.Nombre = request.Nombre;
                    update.Apellido = request.Apellido;
                    update.Correo = request.Correo;
				_context.Entry(update).State = EntityState.Modified;
                    _context.SaveChanges();
					//_context.Empleados.Update(newEmpleado);
                }
            } catch(Exception ex)
            {
				throw new Exception (ex.Message);
            }
        }


		public void Delete (int id)
		{
            try
            {
                Empleados empleado = new();
                using (var _context = new AppDBCContext())
                {
                    empleado = _context.Empleados.Find(id);
                    _context.Empleados.Remove(empleado);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
