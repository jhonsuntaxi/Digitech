using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digitech
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaInsertarPedido : ContentPage
    {
        private const string Url = "http://192.168.100.6/tienda_virtual/pedidoPost.php";
        public VistaInsertarPedido()
        {
            InitializeComponent();
        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient cliente = new HttpClient();

                var parametros = new Dictionary<string, string>();
                parametros.Add("idPedido", txtidPedido.Text);
                parametros.Add("idUsuario", txtidUsuario.Text);
                parametros.Add("idProducto", txtidProducto.Text);
                parametros.Add("estadoPedido", txtestadoPedido.Text);

                var req = new HttpRequestMessage(HttpMethod.Post, Url) { Content = new FormUrlEncodedContent(parametros) };
                var res = await cliente.SendAsync(req);
                await DisplayAlert("Alerta", "Dato ingresado correctamente", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error: " + ex.Message, "ok");
            }

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaConsultarPedidos());
        }
    }
}