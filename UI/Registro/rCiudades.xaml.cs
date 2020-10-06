  
using PrimerParcial.BLL;
using PrimerParcial.DAL;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace PrimerParcial.UI.Registro
{
    public partial class rCiudades: Window
    {
        private Ciudades ciudad = new Ciudades();
        public rCiudades()
        {
            
            InitializeComponent();
            this.DataContext = ciudad;
        }
         
         private void Limpiar()
        {
            ciudad = new Ciudades();
            this.DataContext = ciudad;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado =CiudadesBLL.Buscar(int.Parse(CiudadIdTextBox.Text));

            if (encontrado != null)
            {
                this.ciudad = encontrado;

                this.DataContext = encontrado;
            }

            else
                this.ciudad = new Ciudades();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }


            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = CiudadesBLL.Guardar(ciudad);

            if (paso)
            { 
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

    
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CiudadesBLL.Eliminar(Convert.ToInt32(CiudadIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
    
