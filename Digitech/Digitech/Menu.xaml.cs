using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digitech
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
       
        public Menu(string usuario)
        {
            InitializeComponent();
            lblUser.Text = "Bienvenido: " + usuario;
        }

        private void btnVistaProductos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VistaConsultarProductos());
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Login());

        }

        private void btnVistaUsuarios_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultaRegistro());
        }

        private void btnVistaPedidos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VistaConsultarPedidos());
        }
    }
}