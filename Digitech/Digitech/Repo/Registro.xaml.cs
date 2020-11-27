using Digitech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Digitech
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Usuario = txtUsuario.Text,
                    Password = txtPasswd.Text
                };
                _conn.InsertAsync(datosRegistro);

                limpiarDatos();
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Ok");
            }

        }

        void limpiarDatos()
        {
            DisplayAlert("Alerta", "Datos agregados correctaente", "Ok");
            txtNombre.Text = "";
            txtPasswd.Text = "";
            txtUsuario.Text = "";
        }
    }
}