using Basedadetos.Context;
using Basedadetos.Entities;
using Basedadetos.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Basedadetos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        Empleado empl = new Empleado();
        EmpleadoServices services = new EmpleadoServices();

        #region ***Agregar***
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Falta el nombre del empleado");
            }
            else if (String.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Falta el apellido del empleado");
            }
            else if (String.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Falta el correo del empleado");
            }
            else
            {
                empl.Nombre = txtNombre.Text;
                empl.Apellido = txtApellido.Text;
                empl.Correo = txtCorreo.Text;
                empl.PKEmpleado.ToString();
                

                services.Add(empl);

                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                PKEmpleado.Clear();
                MessageBox.Show("Los datos se guardaron correctamente");
            }

        }

        #endregion

        #region ***Ver***
        private void Btn_Ver_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PKEmpleado.Text, out int id))
            {
                empl = services.Read(id);
                if (empl != null)
                {
                    txtNombre.Text = empl.Nombre;
                    txtApellido.Text = empl.Apellido;
                    txtCorreo.Text = empl.Correo;
                    txtFechaIngreso.Text = empl.FechaRegistro.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró ningún empleado con el ID especificado");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido");
            }
        }

        #endregion

        #region ***Editar***
        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PKEmpleado.Text, out int id))
            {
                EmpleadoServices empleadoServices = new EmpleadoServices();
                Empleado empleado = empleadoServices.Update(id);

                if (empleado != null)
                {
                    empleado.Nombre = txtNombre.Text;
                    empleado.Apellido = txtApellido.Text;
                    empleado.Correo = txtCorreo.Text;

                    try
                    {
                        using (var _context = new AplicationDbContext())
                        {
                            _context.Entry(empleado).State = EntityState.Modified;
                            _context.SaveChanges();
                            MessageBox.Show("Registro actualizado correctamente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al actualizar el registro: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el registro con el ID proporcionado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido");
            }
        }

        #endregion

        #region ***Borrar***
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PKEmpleado.Text, out int id))
            {
                empl = services.Delete(id);
                if (empl != null)
                {
                    MessageBox.Show("Datos borrados correctamente");
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    PKEmpleado.Clear();

                }
                else
                {
                    MessageBox.Show("No se encontró ningún empleado con el ID especificado");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido");
            }
        }
        #endregion

        #region ***Reset***
        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            services.ResetDatabase(); 
            MessageBox.Show("La base de datos ha sido reseteada correctamente");
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            PKEmpleado.Clear();
        }

        #endregion
    }
}
