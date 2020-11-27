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
    public partial class VistaEditarProducto : ContentPage
    {
        private const string Url = "http://192.168.100.6/tienda_virtual/productoPost.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Digitech.Models.Producto> _post;
        public VistaEditarProducto(string id, string nombre, string precio, string foto, string estado)
        {
            InitializeComponent();

            txtidProducto.Text = id.ToString();
            txtnombreProducto.Text = nombre.ToString();
            txtprecioProducto.Text = precio.ToString();
            txturlFotoProducto.Text = foto.ToString();
            txtestadoProducto.Text= estado.ToString();


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
                    parametros.Add("idProducto", txtidProducto.Text);
                    parametros.Add("nombreProducto", txtnombreProducto.Text);
                    parametros.Add("precioProducto", txtprecioProducto.Text);
                    parametros.Add("urlFotoProducto", txturlFotoProducto.Text);
                    parametros.Add("estadoProducto", txtestadoProducto.Text);

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
                    parametros.Add("idProducto", txtidProducto.Text);

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
            await Navigation.PushAsync(new VistaConsultarProductos());
        }
    }
}