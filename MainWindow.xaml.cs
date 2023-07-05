using Diesño.Entities;
using Diesño.Services;
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
using System.Windows.Media;

namespace Diesño
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
        EmpleadoServices services = new();

        public void messageBox (string message)
        {
            string messageBoxText = message;
            string caption = "";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.None;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            string name = txtNombre.Name;
            string apellido = txtApellido.Text;
            string correo = txtCorreo.Text;

            if(name == "" || apellido == "" || correo == "") {
                messageBox("Por favor, ingresa el nombre, apellido y correo electrónico");
            } else
            {
                Color newColor = (Color)ColorConverter.ConvertFromString("#FF24E842");
                Brush newBackgroundBrush = new SolidColorBrush(Colors.Gray);
                Brush newBackgroundBrush2 = new SolidColorBrush(newColor);
                BtnAdd.IsEnabled = false;
                BtnAdd.Background = newBackgroundBrush;
                BtnEdit.IsEnabled = false;
                BtnView.IsEnabled = false;
                Eliminar.IsEnabled = false;
                Empleados empleadoNew = new Empleados()
                {
                    Nombre = name,
                    Apellido = apellido,
                    Correo = correo,
                    FechaRegistro = DateTime.Now
                };
                services.Add(empleadoNew);
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                messageBox("Se ha guardado los datos");
                BtnAdd.IsEnabled = true;
                BtnAdd.Background = newBackgroundBrush2;
                BtnEdit.IsEnabled = true;
                BtnView.IsEnabled = true;
                Eliminar.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Empleados empleado = services.Red(id);

            txtNombre.Text = empleado.Nombre;
            txtCorreo.Text = empleado.Correo;
            txtApellido.Text = empleado.Apellido;
            txtFecha.Text = empleado.FechaRegistro.ToString();
            string v = empleado.PkEmpleado.ToString();
            txtId.Text = v;
        }

        private void BtnUpdate_Clic(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);

            Empleados emplado = new Empleados();
            txtApellido.Text = emplado.Apellido;
            txtCorreo.Text = emplado.Correo;
            txtNombre.Text = emplado.Nombre;

            services.Update(emplado);
        }
    }
}
