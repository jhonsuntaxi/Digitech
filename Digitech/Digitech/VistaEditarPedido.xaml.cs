using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digitech
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaEditarPedido : ContentPage
    {
        private const string Url = "http://192.168.100.6/tienda_virtual/pedidoPost.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Digitech.Models.Pedido> _post;
        public VistaEditarPedido(string id, string idUsuario, string idProducto, string estadoPedido)
        {
            InitializeComponent();

            txtidPedido.Text = id.ToString();
            txtidUsuario.Text = idUsuario.ToString();
            txtidProducto.Text = idProducto.ToString();
            txtestadoPedido.Text = estadoPedido.ToString();


            if (txtidProducto.Text == "")
            {
                DisplayAlert("Alerta", "Es necesario seleccionar un usuario para realizar una operacion", "ok");
            }
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();

                    parametros.Add("idPedido", txtidPedido.Text);
                    parametros.Add("idUsuario", txtidUsuario.Text);
                    parametros.Add("idProducto", txtidProducto.Text);
                    parametros.Add("estadoPedido", txtestadoPedido.Text);

                    cliente.UploadValues(Url, "PUT", cliente.QueryString = parametros);
                }
                await DisplayAlert("Alerta", "Dato Actualizado correctamente", "ok");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error: " + ex.Message, "ok");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("idPedido", txtidPedido.Text);

                    cliente.UploadValues(Url, "DELETE", cliente.QueryString = parametros);

                }
                await DisplayAlert("Alerta", "Dato eliminado correctamente", "ok");
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