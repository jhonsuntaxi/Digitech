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
    public partial class VistaConsultarProductos : ContentPage

        
    {
        private const string Url = "http://192.168.100.6/tienda_virtual/productoPost.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Digitech.Models.Producto> _post;
        public VistaConsultarProductos()
        {
            InitializeComponent();
        }
        
        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Digitech.Models.Producto> posts = JsonConvert.DeserializeObject<List<Digitech.Models.Producto>>(content);
            _post = new ObservableCollection<Models.Producto>(posts);

            MyListView.ItemsSource = _post;

        }

        private async void btnVistaInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaInsertarProducto());
        }

        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Digitech.Models.Producto)e.SelectedItem;
            var id = Convert.ToString(item.idProducto);
            var nombre = item.nombreProducto;
            var precio = Convert.ToString(item.precioProducto);
            var foto = item.urlFotoProducto;
            var estado = Convert.ToString(item.estadoProducto);

            await Navigation.PushAsync(new VistaEditarProducto(id, nombre, precio, foto, estado));
        }

        string usuario;
        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Menu(usuario));
        }
    }
}