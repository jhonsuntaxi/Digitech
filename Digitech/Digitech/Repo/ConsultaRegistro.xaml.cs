using Digitech.Models;
using Digitech.Repo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

using System.Collections.ObjectModel;

namespace Digitech
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Cliente> _TblCliente;
        public ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);

        }

        protected async override void OnAppearing()
        {
            var resultRegistro = await _conn.Table<Cliente>().ToArrayAsync();
            _TblCliente = new ObservableCollection<Cliente>(resultRegistro);
            lstUsuarios.ItemsSource = _TblCliente;
            base.OnAppearing();
        }

        private void lstUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Cliente)e.SelectedItem;
            var item = obj.Id.ToString();
            int Id = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(Id));
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Ok");
            }

        }
    }
}