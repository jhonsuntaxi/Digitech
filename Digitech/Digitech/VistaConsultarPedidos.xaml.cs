using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Digitech
{
    [DesignTimeVisible(false)]
    public partial class VistaConsultarPedidos : ContentPage
    {

        private const string Url = "http://192.168.100.6/tienda_virtual/pedidoPost.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Digitech.Models.Pedido> _post;
        public VistaConsultarPedidos()
        {
            InitializeComponent();
        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {

            var content = await client.GetStringAsync(Url);
            List<Digitech.Models.Pedido> posts = JsonConvert.DeserializeObject<List<Digitech.Models.Pedido>>(content);
            _post = new ObservableCollection<Models.Pedido>(posts);

            MyListView.ItemsSource = _post;

        }

        private async void btnVistaInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaInsertarPedido());
        }

        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Digitech.Models.Pedido)e.SelectedItem;
            var id = Convert.ToString(item.idPedido);
            var idUsuario = Convert.ToString(item.idUsuario);
            var idProducto = Convert.ToString(item.idProducto);
            var estadoPedido = Convert.ToString(item.estadoPedido);

            await Navigation.PushAsync(new VistaEditarPedido(id, idUsuario, idProducto,estadoPedido));
        }

        string usuario;
        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu(usuario));
        }

        
    }
}